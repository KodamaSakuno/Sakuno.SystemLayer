using System;
using System.Collections.Generic;
using System.Text;

namespace Sakuno.SystemLayer
{
    public static class WindowUtil
    {
        public static unsafe string GetClassName(IntPtr windowHandle)
        {
            Span<char> span = stackalloc char[256];
            int length;

            fixed (char* buffer = &span.GetPinnableReference())
                length = NativeMethods.User32.GetClassNameW(windowHandle, buffer, span.Length);

#if NETCOREAPP3_0
            return new string(span[..length]);
#else
            return span.Slice(0, length).ToString();
#endif
        }
        public static unsafe string GetWindowText(IntPtr windowHandle)
        {
            Span<char> span = stackalloc char[256];
            int length;

            fixed (char* buffer = &span.GetPinnableReference())
                length = NativeMethods.User32.GetWindowTextW(windowHandle, buffer, span.Length);

#if NETCOREAPP3_0
            return new string(span[..length]);
#else
            return span.Slice(0, length).ToString();
#endif
        }
    }
}
