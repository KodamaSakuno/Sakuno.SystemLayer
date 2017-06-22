using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class UrlMon
        {
            const string DllName = "urlmon.dll";

            [DllImport(DllName, PreserveSig = true)]
            public static extern int CoInternetSetFeatureEnabled(NativeConstants.INTERNETFEATURELIST FeatureEntry, NativeEnums.SET_FEATURE dwFlags, bool fEnable);

        }
    }
}
