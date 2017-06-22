using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class Ole32
        {
            const string DllName = "ole32.dll";

            [DllImport(DllName, PreserveSig = false)]
            public static extern void PropVariantClear(NativeStructs.PROPVARIANT pvar);

            [DllImport(DllName)]
            public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);
        }
    }
}
