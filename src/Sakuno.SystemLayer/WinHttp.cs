using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class WinHttp
        {
            const string DllName = "winhttp.dll";

            [DllImport(DllName, SetLastError = true)]
            public static extern bool WinHttpGetIEProxyConfigForCurrentUser(out NativeStructs.WINHTTP_CURRENT_USER_IE_PROXY_CONFIG pProxyConfig);
        }
    }
}
