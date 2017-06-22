using System;

namespace Sakuno.SystemLayer.Net
{
    [Flags]
    public enum ConnectivityStates
    {
        None,
        IPv4NoTraffic,
        IPv6NoTraffic = 2,
        IPv4Subnet = 16,
        IPv4LocalNetwork = 32,
        IPv4Internet = 64,
        IPv6Subnet = 256,
        IPv6LocalNetwork = 512,
        IPv6Internet = 1024,
    }
}
