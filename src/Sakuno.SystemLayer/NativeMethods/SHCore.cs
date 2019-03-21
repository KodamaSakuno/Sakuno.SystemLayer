using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class SHCore
        {
            const string DllName = "shcore.dll";

            [DllImport(DllName)]
            public static extern int GetProcessDpiAwareness(IntPtr hprocess, out NativeConstants.PROCESS_DPI_AWARENESS value);
            [DllImport(DllName)]
            public static extern int SetProcessDpiAwareness(NativeConstants.PROCESS_DPI_AWARENESS value);

            [DllImport(DllName)]
            public static extern int GetDpiForMonitor(IntPtr hmonitor, NativeConstants.MONITOR_DPI_TYPE dpiType, out int dpiX, out int dpiY);
        }
    }
}
