using System;

namespace Sakuno.SystemLayer.Net
{
    class NetworkListManagerEventSinks : NativeInterfaces.INetworkListManagerEvents, NativeInterfaces.INetworkEvents, NativeInterfaces.INetworkConnectionEvents
    {
        public uint NLMEventsCookie { get; set; }
        public uint NetworkEventsCookie { get; set; }
        public uint ConnectionEventsCookie { get; set; }

        public void ConnectivityChanged(ConnectivityStates connectivity) =>
            NetworkListManager.OnConnectivityChanged(connectivity);

        public void NetworkAdded(Guid id) => NetworkListManager.OnNetworkAdded(id);
        public void NetworkDeleted(Guid id) => NetworkListManager.OnNetworkRemoved(id);

        public void NetworkConnectivityChanged(Guid id, ConnectivityStates connectivity) =>
            NetworkListManager.OnNetworkConnectivityChanged(id, connectivity);
        public void NetworkPropertyChanged(Guid id, ChangedProperties properties) =>
            NetworkListManager.OnNetworkPropertyChanged(id, properties);

        public void NetworkConnectionConnectivityChanged(Guid id, ConnectivityStates connectivity) =>
            NetworkListManager.OnNetworkConnectionConnectivityChanged(id, connectivity);
        public void NetworkConnectionPropertyChanged(Guid id, ChangedProperties properties) =>
            NetworkListManager.OnNetworkConnectionPropertyChanged(id, properties);
    }
}
