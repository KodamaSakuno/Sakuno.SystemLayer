using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class AdvApi32
        {
            const string DllName = "advapi32.dll";

            [DllImport(DllName)]
            internal static extern int RegNotifyChangeKeyValue(SafeRegistryHandle hKey, [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree, RegistryNotifyFilter dwNotifyFilter, SafeWaitHandle hEvent, [MarshalAs(UnmanagedType.Bool)] bool fAsynchronous);
        }
    }
}
