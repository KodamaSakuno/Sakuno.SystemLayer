using System;

namespace Sakuno.SystemLayer.Audio
{
    public class AudioSessionCreatedEventArgs : EventArgs
    {
        public AudioSession Session { get; }

        public bool Release { get; set; } = true;

        internal AudioSessionCreatedEventArgs(AudioSession session)
        {
            Session = session;
        }
    }
}
