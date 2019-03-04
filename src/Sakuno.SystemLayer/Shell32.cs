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
            public static extern void SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, IntPtr pbc, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out NativeInterfaces.IShellItem ppv);

            [DllImport(DllName)]
            public static extern int SHGetFileInfoW([MarshalAs(UnmanagedType.LPWStr)] string pszPath, FileAttributes dwFileAttributes, out NativeStructs.SHFILEINFO psfi, int cbFileInfo, NativeEnums.SHGFI flags);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName, IntPtr pbc, out IntPtr ppidl, NativeEnums.SFGAO sfgaoIn, out NativeEnums.SFGAO psfgaoOut);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void SHOpenFolderAndSelectItems(IntPtr pidlFolder, int cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, int dwFlags);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void SHGetPropertyStoreForWindow(IntPtr hwnd, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out NativeInterfaces.IPropertyStore ppv);
        }
    }
}
