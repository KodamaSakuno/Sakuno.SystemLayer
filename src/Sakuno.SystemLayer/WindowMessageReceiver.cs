using System;
using System.Windows.Interop;

namespace Sakuno.SystemLayer
{
    public class WindowMessageReceiver
    {
        public static WindowMessageReceiver Instance { get; } = new WindowMessageReceiver();

        HwndSource _source;

        internal HwndSource Source => _source;
        public IntPtr Handle => _source.Handle;

        WindowMessageReceiver()
        {
            _source = new HwndSource(new HwndSourceParameters("Window Message Receiver")
            {
                ParentWindow = NativeConstants.HWND_MESSAGE,
            });
        }

        public void AddHook(HwndSourceHook hook) => _source.AddHook(hook);
        public void RemoveHook(HwndSourceHook hook) => _source.RemoveHook(hook);
    }
}
