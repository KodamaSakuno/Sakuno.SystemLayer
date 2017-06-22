using System;

namespace Sakuno.SystemLayer
{
    [Flags]
    public enum RegistryNotifyFilter
    {
        Name = 1,
        Attributes = 1 << 1,
        LastSet = 1 << 2,
        Security = 1 << 3,
        WatchSubTree = 0x4000,
    }
}
