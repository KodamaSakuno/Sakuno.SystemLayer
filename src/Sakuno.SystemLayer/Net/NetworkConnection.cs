using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Net
{
    public sealed class NetworkConnection : DisposableObject
    {
        NativeInterfaces.INetworkConnection _connection;

        public Network Network => new Network(_connection.GetNetwork());

        public Guid ID => _connection.GetConnectionId();
        public Guid AdapterID => _connection.GetAdapterId();

        public DomainType DomainType => _connection.GetDomainType();

        public ConnectivityStates Connectivity => _connection.GetConnectivity();

        public bool IsConnected => _connection.IsConnected;
        public bool IsConnectedToInternet => _connection.IsConnectedToInternet;

        internal NetworkConnection(NativeInterfaces.INetworkConnection connection) => _connection = connection;

        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_connection);
    }
}
