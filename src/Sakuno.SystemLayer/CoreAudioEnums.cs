using System;

namespace Sakuno.SystemLayer
{
    partial class NativeEnums
    {
        [Flags]
        public enum EndpointHardwareSupport
        {
            Volume = 1,
            Mute = 2,
            Meter = 4,
        }
    }
}
