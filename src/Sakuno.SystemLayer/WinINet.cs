using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class WinINet
        {
            const string DllName = "wininet.dll";

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr FindFirstUrlCacheGroup(int dwFlags, int dwFilter, IntPtr lpSearchCondition, int dwSearchCondition, ref long lpGroupId, IntPtr lpReserved);
            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr FindFirstUrlCacheEntryW([MarshalAs(UnmanagedType.LPWStr)] string lpszUrlSearchPattern, IntPtr lpFirstCacheEntryInfo, ref int lpdwFirstCacheEntryInfoBufferSize);

            [DllImport(DllName, SetLastError = true)]
            public static extern bool FindNextUrlCacheGroup(IntPtr hFind, ref long lpGroupId, IntPtr lpReserved);
            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool FindNextUrlCacheEntryW(IntPtr hFind, IntPtr lpNextCacheEntryInfo, ref int lpdwNextCacheEntryInfoBufferSize);

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern bool DeleteUrlCacheEntryW([MarshalAs(UnmanagedType.LPWStr)] string lpszUrlName);

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr InternetOpenW([MarshalAs(UnmanagedType.LPWStr)] string lpszAgent, NativeConstants.INTERNET_OPEN_TYPE dwAccessType, [MarshalAs(UnmanagedType.LPWStr)] string lpszProxyName, [MarshalAs(UnmanagedType.LPWStr)] string lpszProxyBypass, NativeEnums.INTERNET_FLAG dwFlags);
            [DllImport(DllName, SetLastError = true)]
            public static extern bool InternetCloseHandle(IntPtr hInternet);

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern unsafe bool InternetQueryOptionW(IntPtr hInternet, NativeConstants.INTERNET_OPTION dwOption, void* lpBuffer, ref int lpdwBufferLength);
            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern unsafe bool InternetSetOptionW(IntPtr hInternet, NativeConstants.INTERNET_OPTION dwOption, void* lpBuffer, int lpdwBufferLength);

        }
    }
}
