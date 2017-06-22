using System;

namespace Sakuno.SystemLayer.Audio
{
    [Flags]
    public enum AudioDeviceState
    {
        None,
        Active = 1,
        Disabled = 2,
        NotPresent = 4,
        Unplugged = 8,
        All = 15,
    }
}
