using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Sakuno.SystemLayer
{
    public sealed class RegistryKeyWatcher : DisposableObject
    {
        RegistryKey _baseKey, _key;

        public RegistryKey Key
        {
            get
            {
                ThrowIfDisposed();

                return _key;
            }
        }

        public RegistryNotifyFilter NotifyFilter { get; }

        ManualResetEvent _waitEvent;
        WaitOrTimerCallback _callback;

        RegisteredWaitHandle _registeredWaitHandle;

        EventHandler _handler;
        public event EventHandler Changed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                var handler = _handler;

                _handler = (EventHandler)Delegate.Combine(_handler, value);

                if (handler == null)
                    Register();
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _handler = (EventHandler)Delegate.Remove(_handler, value);

                if (_handler == null)
                    Unregister();
            }
        }

        RegistryKeyWatcher()
        {
            _waitEvent = new ManualResetEvent(false);
            _callback = OnRegistryKeyChanged;
        }
        public RegistryKeyWatcher(RegistryKey key, RegistryNotifyFilter notifyFilter) : this()
        {
            _key = key;

            NotifyFilter = notifyFilter;
        }
        public RegistryKeyWatcher(RegistryHive hive, string name, RegistryNotifyFilter notifyFilter) : this()
        {
            _baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default);
            _key = _baseKey.OpenSubKey(name, false);

            NotifyFilter = notifyFilter;
        }

        protected override void DisposeManagedResources()
        {
            if (_baseKey != null)
            {
                _baseKey.Dispose();
                _baseKey = null;
            }
            if (_key != null)
            {
                _key.Dispose();
                _key = null;
            }
            if (_waitEvent != null)
            {
                _waitEvent.Dispose();
                _waitEvent = null;
            }
        }

        void OnRegistryKeyChanged(object state, bool timedOut)
        {
            if (!IsDisposed)
                _handler?.Invoke(this, EventArgs.Empty);

            Register();
        }

        void Register()
        {
            if (_key == null)
                return;

            var watchSubTree = (NotifyFilter & RegistryNotifyFilter.WatchSubTree) != 0;
            var notifyFilter = NotifyFilter & ~RegistryNotifyFilter.WatchSubTree;

            var result = NativeMethods.AdvApi32.RegNotifyChangeKeyValue(_key.Handle, watchSubTree, notifyFilter, _waitEvent.SafeWaitHandle, true);

            if (NativeUtils.Failed(result))
                throw new Win32Exception(result);

            _registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(_waitEvent, _callback, null, -1, true);
        }
        void Unregister()
        {
            if (Interlocked.Exchange(ref _registeredWaitHandle, null) == null)
                return;

            using (var waitForDone = new ManualResetEvent(true))
                if (_registeredWaitHandle.Unregister(waitForDone))
                    waitForDone.WaitOne();
        }
    }
}
