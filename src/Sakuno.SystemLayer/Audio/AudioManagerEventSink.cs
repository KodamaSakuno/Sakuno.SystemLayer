namespace Sakuno.SystemLayer.Audio
{
    class AudioManagerEventSink : NativeInterfaces.IMMNotificationClient, NativeInterfaces.IAudioSessionNotification
    {
        internal AudioManagerEventSink() { }

        public void OnDefaultDeviceChanged(NativeConstants.DataFlow flow,  NativeConstants.Role role, string defaultDeviceID)
        {
        }

        public void OnDeviceAdded(string deviceId, AudioDeviceState state) { }
        public void OnDeviceRemoved(string deviceId, AudioDeviceState state) { }
        public void OnDeviceStateChanged(string deviceId, AudioDeviceState state) { }
        public void OnPropertyValueChanged(string deviceId, NativeStructs.PROPERTYKEY key) { }

        public void OnSessionCreated(NativeInterfaces.IAudioSessionControl session) =>
            AudioManager.OnSessionCreated(session);
    }
}
