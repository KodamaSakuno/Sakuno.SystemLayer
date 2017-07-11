using Microsoft.Win32.SafeHandles;
using System;
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

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManagerW([MarshalAs(UnmanagedType.LPWStr)] string lpMachineName, [MarshalAs(UnmanagedType.LPWStr)] string lpDatabaseName, NativeEnums.SC_MANAGER_ACCESS_RIGHTS dwDesiredAccess);
            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseServiceHandle(IntPtr hSCObject);

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern unsafe bool EnumServicesStatusExW(IntPtr hSCManager, NativeEnums.SC_ENUM_TYPE InfoLevel, NativeEnums.SERVICE_TYPE dwServiceType, NativeEnums.SERVICE_STATE dwServiceState, IntPtr lpServices, int cbBufSize, out int pcbBytesNeeded, out int lpServicesReturned, ref IntPtr lpResumeHandle, [MarshalAs(UnmanagedType.LPWStr)] string pszGroupName);
        }
    }
}
