using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Sakuno.SystemLayer
{
    public static class PowerManager
    {
        public static bool IsBatteryPresent => GetSystemBatteryState().BatteryPresent;
        public static bool IsCharging => GetSystemBatteryState().Charging;

        public static event Action<int> BatteryRemainingPercentageChanged;
        public static event Action<PowerSource> PowerSourceChanged;
        public static event Action<bool> BatteryChargeStatusChanged;

        public static IDisposable RegisterNotification(Window window)
        {
            var hwndSource = PresentationSource.FromVisual(window) as HwndSource;

            GC.KeepAlive(window);

            if (hwndSource == null)
                return null;

            Guid guid;

            guid = NativeGuids.GUID_BATTERY_PERCENTAGE_REMAINING;
            var batteryPercentageNotification = NativeMethods.User32.RegisterPowerSettingNotification(hwndSource.Handle, ref guid, 0);

            guid = NativeGuids.GUID_ACDC_POWER_SOURCE;
            var powerSourceNotification = NativeMethods.User32.RegisterPowerSettingNotification(hwndSource.Handle, ref guid, 0);

            hwndSource.AddHook(WndProc);

            return Disposable.Create(() =>
            {
                NativeMethods.User32.UnregisterPowerSettingNotification(batteryPercentageNotification);
                NativeMethods.User32.UnregisterPowerSettingNotification(powerSourceNotification);
            });
        }

        static unsafe IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == (int)NativeConstants.WindowMessage.WM_POWERBROADCAST)
            {
                switch ((NativeConstants.PBT)wParam)
                {
                    case NativeConstants.PBT.PBT_APMPOWERSTATUSCHANGE:
                        BatteryChargeStatusChanged?.Invoke(GetSystemBatteryState().Charging);
                        break;

                    case NativeConstants.PBT.PBT_POWERSETTINGCHANGE:
                        var setting = (NativeStructs.POWERBROADCAST_SETTING*)lParam;

                        if (setting->PowerSetting == NativeGuids.GUID_BATTERY_PERCENTAGE_REMAINING)
                            BatteryRemainingPercentageChanged?.Invoke(setting->Data);
                        else if (setting->PowerSetting == NativeGuids.GUID_ACDC_POWER_SOURCE)
                            PowerSourceChanged?.Invoke((PowerSource)setting->Data);
                        break;
                }
            }

            return IntPtr.Zero;
        }

        public static NativeStructs.SYSTEM_BATTERY_STATE GetSystemBatteryState()
        {
            NativeMethods.PowrProf.CallNtPowerInformation(NativeConstants.POWER_INFORMATION_LEVEL.SystemBatteryState, IntPtr.Zero, 0, out var state, Marshal.SizeOf(typeof(NativeStructs.SYSTEM_BATTERY_STATE)));

            return state;
        }
    }
}
