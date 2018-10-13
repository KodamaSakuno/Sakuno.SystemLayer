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

        public void OnSimpleVolumeChanged(float volume, bool mute, in Guid eventContext)
        {
            _owner.OnVolumeChanged(new AudioSessionVolumeChangedEventArgs(mute, (int)(volume * 100)));
        }

        public void OnStateChanged(AudioSessionState state)
        {
            _owner.OnStateChanged(state);
        }

        public void OnChannelVolumeChanged(uint channelCount, IntPtr newChannelVolumeArray, uint changedChannel, in Guid eventContext) { }
        public void OnDisplayNameChanged(string newDisplayName, in Guid eventContext) { }
        public void OnGroupingParamChanged(in Guid newGroupingParam, in Guid eventContext) { }
        public void OnIconPathChanged(string newIconPath, in Guid eventContext) { }
    }
}
