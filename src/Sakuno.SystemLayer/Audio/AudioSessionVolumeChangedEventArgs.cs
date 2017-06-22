using System;

namespace Sakuno.SystemLayer.Audio
{
    public class AudioSessionVolumeChangedEventArgs : EventArgs
    {
        public bool IsMute { get; }
        public int Volume { get; }

        public AudioSessionVolumeChangedEventArgs(bool isMute, int volume)
        {
            IsMute = isMute;
            Volume = volume;
        }
    }
}
