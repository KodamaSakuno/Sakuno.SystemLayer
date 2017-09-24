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
        public static int HiWord(this IntPtr value) => (int)(value.ToInt64() >> 16 & 0xFFFFL);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int LoWord(this IntPtr value) => (int)(value.ToInt64() & 0xFFFFL);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MakeParam(int lowWord, int highWord) => (IntPtr)(lowWord & 0xFFFF | highWord << 16);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Point ToPoint(this IntPtr value) => new Point(value.LoWord(), value.HiWord());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr MAKEINTRESOURCEW(int value) => (IntPtr)(ushort)value;
    }
}
