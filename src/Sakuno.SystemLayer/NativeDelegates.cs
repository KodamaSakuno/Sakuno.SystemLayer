using System;

namespace Sakuno.SystemLayer
{
    public static partial class NativeDelegates
    {
        public delegate IntPtr WindowProc(IntPtr hwnd, NativeConstants.WindowMessage uMsg, IntPtr wParam, IntPtr lParam);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        internal delegate int TaskDialogCallbackProc(IntPtr hwnd, NativeConstants.TASKDIALOG_NOTIFICATIONS uNotification, IntPtr wParam, IntPtr lParam, IntPtr dwRefData);

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
