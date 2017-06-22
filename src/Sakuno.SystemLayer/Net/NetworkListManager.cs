using System;
using System.Collections.Generic;

namespace Sakuno.SystemLayer.Net
{
    public static class NetworkListManager
    {
        static NativeInterfaces.INetworkListManager _manager;

        public static ConnectivityStates Connectivity => _manager.GetConnectivity();

        public static bool IsConnected => _manager.IsConnected;
        public static bool IsConnectedToInternet => _manager.IsConnectedToInternet;

        static NetworkListManagerEventSinks _eventSinks;

        public static event Action<ConnectivityStates> ConnectivityChanged;

        public static event Action<Guid> NetworkAdded;
        public static event Action<Guid> NetworkRemoved;
        public static event Action<Guid, ConnectivityStates> NetworkConnectivityChanged;
        public static event Action<Guid, ChangedProperties> NetworkPropertyChanged;

        public static event Action<Guid, ConnectivityStates> NetworkConnectionConnectivityChanged;
        public static event Action<Guid, ChangedProperties> NetworkConnectionPropertyChanged;

        static NetworkListManager()
        {
            _manager = (NativeInterfaces.INetworkListManager)new NativeInterfaces.NetworkListManager();

            _eventSinks = new NetworkListManagerEventSinks();

            var connectionPointContainer = (NativeInterfaces.IConnectionPointContainer)_manager;

            var guid = typeof(NativeInterfaces.INetworkListManagerEvents).GUID;
            _eventSinks.NLMEventsCookie = connectionPointContainer.FindConnectionPoint(ref guid).Advise(_eventSinks);

            guid = typeof(NativeInterfaces.INetworkEvents).GUID;
            _eventSinks.NetworkEventsCookie = connectionPointContainer.FindConnectionPoint(ref guid).Advise(_eventSinks);

            guid = typeof(NativeInterfaces.INetworkConnectionEvents).GUID;
            _eventSinks.ConnectionEventsCookie = connectionPointContainer.FindConnectionPoint(ref guid).Advise(_eventSinks);
        }

        public static Network GetNetwork(Guid id) => new Network(_manager.GetNetwork(id));
        public static NetworkConnection GetNetworkConnection(Guid id)
        {
            var connection = _manager.GetNetworkConnection(id);

            return connection != null ? new NetworkConnection(connection) : null;
        }

        public static IEnumerable<Network> GetNetworks(NetworkTypes types)
        {
            foreach (NativeInterfaces.INetwork network in _manager.GetNetworks(types))
                yield return new Network(network);
        }
        public static IEnumerable<NetworkConnection> GetNetworkConnections()
        {
            foreach (NativeInterfaces.INetworkConnection connection in _manager.GetNetworkConnections())
                yield return new NetworkConnection(connection);
        }

        internal static void OnConnectivityChanged(ConnectivityStates connectivity) =>
            ConnectivityChanged?.Invoke(connectivity);

        internal static void OnNetworkAdded(Guid id) => NetworkAdded?.Invoke(id);
        internal static void OnNetworkRemoved(Guid id) => NetworkRemoved?.Invoke(id);
        internal static void OnNetworkConnectivityChanged(Guid id, ConnectivityStates connectivity) =>
            NetworkConnectivityChanged?.Invoke(id, connectivity);
        internal static void OnNetworkPropertyChanged(Guid id, ChangedProperties properties) =>
            NetworkPropertyChanged?.Invoke(id, properties);

        internal static void OnNetworkConnectionConnectivityChanged(Guid id, ConnectivityStates connectivity) =>
            NetworkConnectionConnectivityChanged?.Invoke(id, connectivity);
        internal static void OnNetworkConnectionPropertyChanged(Guid id, ChangedProperties properties) =>
            NetworkConnectionPropertyChanged?.Invoke(id, properties);
    }
}
