using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sakuno.SystemLayer
{
    public static class PowerManager
    {
        public static bool IsBatteryPresent => GetSystemBatteryState().BatteryPresent;
        public static bool IsCharging => GetSystemBatteryState().Charging;

        public static event Action<int> BatteryRemainingPercentageChanged;
        public static event Action<PowerSource> PowerSourceChanged;
        public static event Action<bool> BatteryChargeStatusChanged;

        static IDisposable _subscription;
        static IntPtr _batteryPercentageNotification, _powerSourceNotification;

        public static IDisposable SubscribeNotification()
        {
            if (_subscription != null)
                return _subscription;

            var handle = WindowMessageReceiver.Instance.Handle;

            Guid guid;

            guid = NativeGuids.GUID_BATTERY_PERCENTAGE_REMAINING;
            _batteryPercentageNotification = NativeMethods.User32.RegisterPowerSettingNotification(handle, ref guid, 0);

            guid = NativeGuids.GUID_ACDC_POWER_SOURCE;
            _powerSourceNotification = NativeMethods.User32.RegisterPowerSettingNotification(handle, ref guid, 0);

            WindowMessageReceiver.Instance.AddHook(WndProc);

            var subscription = Disposable.Create(UnsubscribeNotification);

            Volatile.Write(ref _subscription, subscription);

            return subscription;
        }

        public static void UnsubscribeNotification()
        {
            if (Interlocked.Exchange(ref _subscription, null) == null)
                return;

            WindowMessageReceiver.Instance.RemoveHook(WndProc);

            NativeMethods.User32.UnregisterPowerSettingNotification(_batteryPercentageNotification);
            NativeMethods.User32.UnregisterPowerSettingNotification(_powerSourceNotification);

            _batteryPercentageNotification = IntPtr.Zero;
            _powerSourceNotification = IntPtr.Zero;
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
