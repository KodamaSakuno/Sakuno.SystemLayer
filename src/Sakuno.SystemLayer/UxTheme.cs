using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class UxTheme
        {
            const string DllName = "uxtheme.dll";

            [DllImport(DllName, EntryPoint = "#94")]
            public static extern int GetImmersiveColorSetCount();

            [DllImport(DllName, EntryPoint = "#95")]
            public static extern NativeStructs.RGBA GetImmersiveColorFromColorSetEx(int dwImmersiveColorSet, int dwImmersiveColorType, bool bIgnoreHighContrast, int dwHighContrastCacheMode);

            [DllImport(DllName, EntryPoint = "#96", CharSet = CharSet.Unicode)]
            public static extern int GetImmersiveColorTypeFromName(string name);

            [DllImport(DllName, EntryPoint = "#98")]
            public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

            [DllImport(DllName, EntryPoint = "#100")]
            public static extern IntPtr GetImmersiveColorNamedTypeByIndex(int dwIndex);

            [DllImport(DllName, EntryPoint = "#105")]
            public static extern int GetImmersiveDefaultColorSet();
        }
    }
}
