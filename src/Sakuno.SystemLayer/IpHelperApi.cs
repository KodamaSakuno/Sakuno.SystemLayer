using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class IPHelperApi
        {
            const string DllName = "iphlpapi.dll";

            [DllImport(DllName, SetLastError = true)]
            public static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int pdwSize, bool bOrder, NativeConstants.AF ulAf, NativeConstants.TCP_TABLE_CLASS TableClass, int Reserved = 0);
        }
    }
}
