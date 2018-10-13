using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sakuno.SystemLayer.Audio
{
    public static class AudioManager
    {
        static NativeInterfaces.IMMDeviceEnumerator _deviceEnumerator;
        static NativeInterfaces.IAudioSessionManager2 _sessionManager;

        static AudioManagerEventSink _eventSink;
        static IDisposable _subscription;

        public static AudioDevice DefaultDevice { get; internal set; }

        public static event Action<AudioSessionCreatedEventArgs> NewSession;

        static AudioManager()
        {
            _deviceEnumerator = (NativeInterfaces.IMMDeviceEnumerator)new NativeInterfaces.MMDeviceEnumerator();

            var device = _deviceEnumerator.GetDefaultAudioEndpoint(NativeConstants.DataFlow.Render, NativeConstants.Role.Console);

            DefaultDevice = new AudioDevice(device);

            var obj = device.Activate(typeof(NativeInterfaces.IAudioSessionManager2).GUID, 0, IntPtr.Zero);

            _sessionManager = (NativeInterfaces.IAudioSessionManager2)obj;

            _eventSink = new AudioManagerEventSink();
            _deviceEnumerator.RegisterEndpointNotificationCallback(_eventSink);
        }

        public static void ReloadDefaultDevice()
        {
            DefaultDevice?.Dispose();

            var device = _deviceEnumerator.GetDefaultAudioEndpoint(NativeConstants.DataFlow.Render, NativeConstants.Role.Console);

            DefaultDevice = new AudioDevice(device);
        }

        public static IEnumerable<AudioSession> EnumerateSessions()
        {
            var sessionEnumerator = _sessionManager.GetSessionEnumerator();
            var count = sessionEnumerator.GetCount();

            try
            {
                for (var i = 0; i < count; i++)
                {
                    var sessionControl = sessionEnumerator.GetSession(i);

                    yield return new AudioSession((NativeInterfaces.IAudioSessionControl2)sessionControl);
                }
            }
            finally
            {
                Marshal.ReleaseComObject(sessionEnumerator);
            }
        }

        public static IDisposable SubscribeSessionNotification()
        {
            if (_subscription != null)
                return _subscription;

            Marshal.ReleaseComObject(_sessionManager.GetSessionEnumerator());

            _sessionManager.RegisterSessionNotification(_eventSink);

            var subscription = Disposable.Create(UnsubscribeSessionNotification);

            Volatile.Write(ref _subscription, subscription);

            return subscription;
        }
        public static void UnsubscribeSessionNotification()
        {
            if (Interlocked.Exchange(ref _subscription, null) == null)
                return;

            _sessionManager.UnregisterSessionNotification(_eventSink);
        }

        internal static void OnSessionCreated(NativeInterfaces.IAudioSessionControl newSession)
        {
            if (newSession == null)
                return;

            var args = new AudioSessionCreatedEventArgs(new AudioSession((NativeInterfaces.IAudioSessionControl2)newSession));

            NewSession?.Invoke(args);

            if (args.Release)
                args.Session.Dispose();
        }
    }
}
