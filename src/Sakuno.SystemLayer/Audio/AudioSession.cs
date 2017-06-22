using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Audio
{
    public class AudioSession : DisposableObject
    {
        static Guid _emptyGuid = Guid.Empty;

        NativeInterfaces.IAudioSessionControl2 _session;
        NativeInterfaces.ISimpleAudioVolume _simpleAudioVolume;

        AudioSessionEventSink _eventSink;

        public bool IsSystemSoundsSession => _session.IsSystemSoundsSession() == 0;

        public int ProcessID => _session.GetProcessId();

        public AudioSessionState State => _session.GetState();

        public int Volume
        {
            get => (int)(_simpleAudioVolume.GetMasterVolume() * 100);
            set => _simpleAudioVolume.SetMasterVolume((float)(value / 100.0), ref _emptyGuid);
        }
        public bool IsMute
        {
            get => _simpleAudioVolume.GetMute();
            set => _simpleAudioVolume.SetMute(value, ref _emptyGuid);
        }

        public string DisplayName
        {
            get => _session.GetDisplayName();
            set => _session.SetDisplayName(value, ref _emptyGuid);
        }

        public event EventHandler<AudioSessionDisconnectReason> Disconnected;
        public event EventHandler<AudioSessionVolumeChangedEventArgs> VolumeChanged;
        public event EventHandler<AudioSessionState> StateChanged;

        internal AudioSession(NativeInterfaces.IAudioSessionControl2 session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _simpleAudioVolume = (NativeInterfaces.ISimpleAudioVolume)session;

            _eventSink = new AudioSessionEventSink(this);
            _session.RegisterAudioSessionNotification(_eventSink);
        }

        protected override void DisposeNativeResources()
        {
            _session.UnregisterAudioSessionNotification(_eventSink);

            Marshal.ReleaseComObject(_session);

            _session = null;
            _simpleAudioVolume = null;
        }

        internal void OnSessionDisconnected(AudioSessionDisconnectReason disconnectReason) => Disconnected?.Invoke(this, disconnectReason);
        internal void OnVolumeChanged(AudioSessionVolumeChangedEventArgs e) => VolumeChanged?.Invoke(this, e);
        internal void OnStateChanged(AudioSessionState state) => StateChanged?.Invoke(this, state);
    }
}
