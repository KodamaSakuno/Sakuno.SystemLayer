using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Sakuno.SystemLayer
{
    partial class NativeMethods
    {
        public static class User32
        {
            const string DllName = "user32.dll";

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern int SendMessageW(IntPtr hWnd, NativeConstants.WindowMessage Msg, IntPtr wParam, IntPtr lParam);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PostMessageW(IntPtr hWnd, NativeConstants.WindowMessage Msg, IntPtr wParam, IntPtr lParam);

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr GetParent(IntPtr hWnd);
            [DllImport(DllName)]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, NativeEnums.SetWindowPosition uFlags);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ShowWindow(IntPtr hWnd, NativeConstants.ShowCommand nCmdShow);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ShowWindowAsync(IntPtr hWnd, NativeConstants.ShowCommand nCmdShow);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, out NativeStructs.RECT lpRect);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowPlacement(IntPtr hWnd, out NativeStructs.WINDOWPLACEMENT lpwndpl);
            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPlacement(IntPtr hWnd, ref NativeStructs.WINDOWPLACEMENT lpwndpl);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetCursorPos(out NativeStructs.POINT lpPoint);
            [DllImport(DllName, SetLastError = true)]
            public static extern bool SetCursorPos(int X, int Y);

            [DllImport(DllName)]
            public static extern IntPtr GetForegroundWindow();
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr GetTopWindow(IntPtr hWnd);
            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr GetWindow(IntPtr hWnd, NativeConstants.GetWindow uCmd);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumWindows(NativeDelegates.EnumWindowsProc lpEnumFunc, IntPtr lParam);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumChildWindows(IntPtr hwndParent, NativeDelegates.EnumWindowsProc lpEnumFunc, IntPtr lParam);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumThreadWindows(int dwThreadId, NativeDelegates.EnumWindowsProc lpEnumFunc, IntPtr lParam);

            [DllImport(DllName, CharSet = CharSet.Unicode)]
            public static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpClassName, int nMaxCount);
            [DllImport(DllName, CharSet = CharSet.Unicode)]
            public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpText, int nMaxCount);

            #region Window Long

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr GetWindowLongPtr(IntPtr hWnd, NativeConstants.GetWindowLong nIndex) =>
                new IntPtr(OS.Is64Bit ? WindowLong.GetWindowLongPtrW(hWnd, nIndex) : WindowLong.GetWindowLongW(hWnd, nIndex));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr SetWindowLongPtr(IntPtr hWnd, NativeConstants.GetWindowLong nIndex, IntPtr dwNewLong) =>
                OS.Is64Bit ? WindowLong.SetWindowLongPtrW(hWnd, nIndex, dwNewLong) : new IntPtr(WindowLong.SetWindowLongW(hWnd, nIndex, dwNewLong.ToInt32()));

            static class WindowLong
            {
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern int GetWindowLongW(IntPtr hWnd, NativeConstants.GetWindowLong nIndex);
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern long GetWindowLongPtrW(IntPtr hWnd, NativeConstants.GetWindowLong nIndex);

                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern int SetWindowLongW(IntPtr hWnd, NativeConstants.GetWindowLong nIndex, int dwNewLong);
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern IntPtr SetWindowLongPtrW(IntPtr hWnd, NativeConstants.GetWindowLong nIndex, IntPtr dwNewLong);
            }

            #endregion

            #region Class Long

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr GetClassLongPtr(IntPtr hWnd, NativeConstants.GetClassLong nIndex) =>
                new IntPtr(OS.Is64Bit ? ClassLong.GetClassLongPtrW(hWnd, nIndex) : ClassLong.GetClassLongW(hWnd, nIndex));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr SetClassLongPtr(IntPtr hWnd, NativeConstants.GetClassLong nIndex, IntPtr dwNewLong) =>
                OS.Is64Bit ? ClassLong.SetClassLongPtrW(hWnd, nIndex, dwNewLong) : new IntPtr(ClassLong.SetClassLongW(hWnd, nIndex, dwNewLong.ToInt32()));

            static class ClassLong
            {
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern int GetClassLongW(IntPtr hWnd, NativeConstants.GetClassLong nIndex);
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern long GetClassLongPtrW(IntPtr hWnd, NativeConstants.GetClassLong nIndex);

                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern int SetClassLongW(IntPtr hWnd, NativeConstants.GetClassLong nIndex, int dwNewLong);
                [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
                public static extern IntPtr SetClassLongPtrW(IntPtr hWnd, NativeConstants.GetClassLong nIndex, IntPtr dwNewLong);
            }

            #endregion

            [DllImport(DllName, CharSet = CharSet.Auto)]
            public static extern bool SystemParametersInfo(NativeConstants.SPI uiAction, int uiParam, ref NativeStructs.RECT pvParam, int fWinIni);

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport(DllName)]
            public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ClientToScreen(IntPtr hWnd, ref NativeStructs.POINT lpPoint);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ScreenToClient(IntPtr hWnd, ref NativeStructs.POINT lpPoint);

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr RegisterPowerSettingNotification(IntPtr hRecipient, ref Guid PowerSettingGuid, int Flags);
            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnregisterPowerSettingNotification(IntPtr Handle);

            [DllImport(DllName)]
            public static extern IntPtr MonitorFromWindow(IntPtr hwnd, NativeConstants.MFW dwFlags);
            [DllImport(DllName)]
            public static extern bool GetMonitorInfo(IntPtr hMonitor, ref NativeStructs.MONITORINFO lpmi);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FlashWindowEx(ref NativeStructs.FLASHWINFO pwfi);

            [DllImport(DllName)]
            public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
            [DllImport(DllName)]
            public static extern bool EnableMenuItem(IntPtr hMenu, NativeConstants.SystemCommand uIDEnableItem, NativeEnums.MF uEnable);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public extern static bool GetAutoRotationState(out NativeEnums.AR_STATE pState);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, NativeEnums.ModifierKeys fsModifiers, int vk);
            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            [DllImport(DllName)]
            public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

            [DllImport(DllName)]
            public static extern int GetSystemMetrics(NativeConstants.SystemMetrics nIndex);

            [DllImport(DllName)]
            public static extern IntPtr WindowFromPoint(NativeStructs.POINT Point);
            [DllImport(DllName)]
            public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, NativeStructs.POINT Point);
            [DllImport(DllName)]
            public static extern IntPtr RealChildWindowFromPoint(IntPtr hwndParent, NativeStructs.POINT ptParentClientCoords);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DestroyIcon(IntPtr hIcon);

            [DllImport(DllName, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(NativeConstants.WindowsHook idHook, NativeDelegates.HookProc lpfn, IntPtr hMod, int dwThreadID);
            [DllImport(DllName, SetLastError = true)]
            public static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport(DllName, SetLastError = true)]
            public static extern short RegisterClassEx(ref NativeStructs.WNDCLASSEX lpwcx);

            [DllImport(DllName, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr CreateWindowExW(NativeEnums.ExtendedWindowStyle dwExStyle, [MarshalAs(UnmanagedType.LPWStr)] string lpClassName, [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName, NativeEnums.WindowStyle dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

            [DllImport(DllName, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ChangeWindowMessageFilterEx(IntPtr hWnd, NativeConstants.WindowMessage message, int action, IntPtr pChangeFilterStruct);

            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWindowVisible(IntPtr hWnd);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsIconic(IntPtr hWnd);
            [DllImport(DllName)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsZoomed(IntPtr hWnd);

            [DllImport(DllName, SetLastError = true)]
            public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref NativeStructs.WINDOWCOMPOSITIONATTRIBDATA pAttrData);
        }
    }
}
