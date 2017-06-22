using System;

namespace Sakuno.SystemLayer.Net
{
    [Flags]
    public enum NetworkTypes
    {
        Connected = 1,
        Disconnected,
        All,
    }
}
