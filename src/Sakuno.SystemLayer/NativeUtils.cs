using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Sakuno.SystemLayer
{
    public static class NativeUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Succeeded(int result) => result >= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Failed(int result) => result < 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort HiWord(this IntPtr value) => (ushort)(value.ToInt64() >> 0x10 & 0xFFFFL);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort LoWord(this IntPtr value) => (ushort)(value.ToInt64() & 0xFFFFL);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point ToPoint(this IntPtr value) => new Point(value.LoWord(), value.HiWord());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MAKEINTRESOURCEW(int value) => (IntPtr)(ushort)value;
    }
}
