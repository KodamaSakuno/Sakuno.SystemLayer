using Sakuno.SystemLayer.Audio;
using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeInterfaces
    {
        [ComImport]
        [Guid("D666063F-1587-4E43-81F1-B948E807363F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMDevice
        {
            [return: MarshalAs(UnmanagedType.IUnknown)]
            object Activate(ref Guid iid, uint dwClsCtx, IntPtr pActivationParams);
            IPropertyStore OpenPropertyStore(NativeConstants.STGM stgmAccess);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetId();
            AudioDeviceState GetState();
        }

        [ComImport]
        [Guid("7991EEC9-7E89-4D85-8390-6C703CEC60C0")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMNotificationClient
        {
            void OnDeviceStateChanged([MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, AudioDeviceState dwNewState);
            void OnDeviceAdded([MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, AudioDeviceState dwNewState);
            void OnDeviceRemoved([MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, AudioDeviceState dwNewState);
            void OnDefaultDeviceChanged(NativeConstants.DataFlow flow, NativeConstants.Role role, [MarshalAs(UnmanagedType.LPWStr)] string pwstrDefaultDeviceId);
            void OnPropertyValueChanged([MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, NativeStructs.PROPERTYKEY key);
        }

        [ComImport]
        [Guid("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMDeviceCollection
        {
            int GetCount();
            IMMDevice Item(int nDevice);
        }

        [ComImport]
        [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IMMDeviceEnumerator
        {
            IMMDeviceCollection EnumAudioEndpoints(NativeConstants.DataFlow dataFlow, AudioDeviceState role);
            IMMDevice GetDefaultAudioEndpoint(NativeConstants.DataFlow dataFlow, NativeConstants.Role role);
            IMMDevice GetDevice([MarshalAs(UnmanagedType.LPWStr)] string pwstrId);
            void RegisterEndpointNotificationCallback(IMMNotificationClient pNotify);
            void UnregisterEndpointNotificationCallback(IMMNotificationClient pNotify);
        }
        [ComImport]
        [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        [ClassInterface(ClassInterfaceType.None)]
        internal class MMDeviceEnumerator { }

        [ComImport]
        [Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ISimpleAudioVolume
        {
            void SetMasterVolume(float fLevel, ref Guid EventContext);
            float GetMasterVolume();
            void SetMute(bool bMute, ref Guid EventContext);
            bool GetMute();
        }

        [ComImport]
        [Guid("BFA971F1-4D5E-40BB-935E-967039BFBEE4")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionManager
        {
            IAudioSessionControl GetAudioSessionControl(ref Guid AudioSessionGuid, uint StreamFlags);
            ISimpleAudioVolume GetSimpleAudioVolume(ref Guid AudioSessionGuid, uint StreamFlags);
        }
        [ComImport]
        [Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionManager2
        {
            IAudioSessionControl GetAudioSessionControl(ref Guid AudioSessionGuid, uint StreamFlags);
            ISimpleAudioVolume GetSimpleAudioVolume(ref Guid AudioSessionGuid, uint StreamFlags);
            IAudioSessionEnumerator GetSessionEnumerator();
            void RegisterSessionNotification(IAudioSessionNotification SessionNotification);
            void UnregisterSessionNotification(IAudioSessionNotification SessionNotification);

            // Need more implement
        }
        [ComImport]
        [Guid("641DD20B-4D41-49CC-ABA3-174B9477BB08")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionNotification
        {
            void OnSessionCreated(IAudioSessionControl NewSession);
        }

        [ComImport]
        [Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionEnumerator
        {
            int GetCount();
            IAudioSessionControl GetSession(int SessionCount);
        }

        [ComImport]
        [Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionControl
        {
            AudioSessionState GetState();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName();
            void SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, Guid EventContext);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetIconPath();
            void SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, ref Guid EventContext);
            Guid GetGroupingParam();
            void SetGroupingParam(ref Guid Override, ref Guid EventContext);
            void RegisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
            void UnregisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
        }
        [ComImport]
        [Guid("BFB7FF88-7239-4FC9-8FA2-07C950BE9C6D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionControl2
        {
            AudioSessionState GetState();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDisplayName();
            void SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, ref Guid EventContext);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetIconPath();
            void SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, ref Guid EventContext);
            Guid GetGroupingParam();
            void SetGroupingParam(ref Guid Override, ref Guid EventContext);
            void RegisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
            void UnregisterAudioSessionNotification(IAudioSessionEvents NewNotifications);
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetSessionIdentifier();
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetSessionInstanceIdentifier();
            int GetProcessId();
            [PreserveSig]
            int IsSystemSoundsSession();
            void SetDuckingPreference(bool optOut);
        }
        [ComImport]
        [Guid("24918ACC-64B3-37C1-8CA9-74A66E9957A8")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IAudioSessionEvents
        {
            void OnDisplayNameChanged([MarshalAs(UnmanagedType.LPWStr)] string NewDisplayName, ref Guid EventContext);
            void OnIconPathChanged([MarshalAs(UnmanagedType.LPWStr)] string NewIconPath, ref Guid EventContext);
            void OnSimpleVolumeChanged(float NewVolume, bool NewMute, ref Guid EventContext);
            void OnChannelVolumeChanged(uint ChannelCount, IntPtr NewChannelVolumeArray, uint ChangedChannel, ref Guid EventContext);
            void OnGroupingParamChanged(ref Guid NewGroupingParam, ref Guid EventContext);
            void OnStateChanged(AudioSessionState NewState);
            void OnSessionDisconnected(AudioSessionDisconnectReason DisconnectReason);
        }
    }
}
