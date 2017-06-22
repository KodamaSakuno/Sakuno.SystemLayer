using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class DwmApi
        {
            const string DllName = "dwmapi.dll";

            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmIsCompositionEnabled([MarshalAs(UnmanagedType.Bool)] out bool pfEnabled);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmEnableComposition([MarshalAs(UnmanagedType.Bool)] bool uCompositionAction);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref NativeStructs.MARGINS pMarInset);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmRegisterThumbnail(IntPtr hwndDestination, IntPtr hwndSource, out IntPtr phThumbnailId);
            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmUnregisterThumbnail(IntPtr hThumbnailId);

            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmQueryThumbnailSourceSize(IntPtr hThumbnail, out NativeStructs.SIZE pSize);
            [DllImport(DllName, PreserveSig = false)]
            public static extern void DwmUpdateThumbnailProperties(IntPtr hThumbnailId, ref NativeStructs.DWM_THUMBNAIL_PROPERTIES ptnProperties);

        }
    }
}
