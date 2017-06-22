using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class PowrProf
        {
            const string DllName = "powrprof.dll";

            [DllImport(DllName)]
            public static extern int CallNtPowerInformation(NativeConstants.POWER_INFORMATION_LEVEL InformationLevel, IntPtr lpInputBuffer, int nInputBufferSize, out NativeStructs.SYSTEM_BATTERY_STATE lpOutputBuffer, int nOutputBufferSize);
        }
    }
}
