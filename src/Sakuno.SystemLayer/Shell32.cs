using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class Shell32
        {
            const string DllName = "shell32.dll";

            [DllImport(DllName, PreserveSig = false)]
            public static extern void SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IntPtr pbc, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out NativeInterfaces.IShellItem ppv);

            [DllImport(DllName)]
            public static extern int SHGetFileInfoW([MarshalAs(UnmanagedType.LPWStr)] string pszPath, FileAttributes dwFileAttributes, out NativeStructs.SHFILEINFO psfi, int cbFileInfo, NativeEnums.SHGFI flags);
        }
    }
}
