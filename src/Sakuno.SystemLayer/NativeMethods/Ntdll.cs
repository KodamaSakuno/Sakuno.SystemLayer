using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class Ntdll
        {
            const string DllName = "ntdll.dll";

            [DllImport(DllName)]
            public static extern IntPtr NtSuspendProcess(IntPtr ProcessHandle);
            [DllImport(DllName)]
            public static extern IntPtr NtResumeProcess(IntPtr ProcessHandle);

            [DllImport(DllName, SetLastError = true)]
            public static extern uint NtQueryTimerResolution(out uint MinimumResolution, out uint MaximumResolution, out uint CurrentResolution);
        }
    }
}
