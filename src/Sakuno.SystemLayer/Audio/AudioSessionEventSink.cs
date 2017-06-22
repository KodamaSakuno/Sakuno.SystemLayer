using System;

namespace Sakuno.SystemLayer.Audio
{
    class AudioSessionEventSink : NativeInterfaces.IAudioSessionEvents
    {
        AudioSession _owner;

        public AudioSessionEventSink(AudioSession session)
        {
            _owner = session;
        }

        public void OnSessionDisconnected(AudioSessionDisconnectReason disconnectReason)
        {
            _owner.OnSessionDisconnected(disconnectReason);
        }

        public void OnSimpleVolumeChanged(float volume, bool mute, ref Guid eventContext)
        {
            _owner.OnVolumeChanged(new AudioSessionVolumeChangedEventArgs(mute, (int)(volume * 100)));
        }

        public void OnStateChanged(AudioSessionState state)
        {
            _owner.OnStateChanged(state);
        }

        public void OnChannelVolumeChanged(uint channelCount, IntPtr newChannelVolumeArray, uint changedChannel, ref Guid eventContext) { }
        public void OnDisplayNameChanged(string newDisplayName, ref Guid eventContext) { }
        public void OnGroupingParamChanged(ref Guid newGroupingParam, ref Guid eventContext) { }
        public void OnIconPathChanged(string newIconPath, ref Guid eventContext) { }
    }
}
