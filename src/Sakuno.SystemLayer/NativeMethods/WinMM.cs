using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class WinMM
        {
            const string DllName = "winmm.dll";

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PlaySound(IntPtr pszSound, IntPtr hmod, NativeEnums.SND fdwSound);
            [DllImport(DllName, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PlaySoundW([MarshalAs(UnmanagedType.LPWStr)] string pszSound, IntPtr hmod, NativeEnums.SND fdwSound);
        }
    }
}
