using Sakuno.SystemLayer.Net;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer
{
    partial class NativeInterfaces
    {
        [ComImport]
        [Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B")]
        [TypeLibType(TypeLibTypeFlags.FDispatchable)]
        internal interface INetworkListManager
        {
            IEnumerable GetNetworks(NetworkTypes Flags);
            INetwork GetNetwork(Guid gdNetworkId);
            IEnumerable GetNetworkConnections();
            INetworkConnection GetNetworkConnection(Guid gdNetworkConnectionId);
            bool IsConnectedToInternet { get; }
            bool IsConnected { get; }
            ConnectivityStates GetConnectivity();
        }
        [ComImport]
        [Guid("DCB00C01-570F-4A9B-8D69-199FDBA5723B")]
        [ClassInterface(ClassInterfaceType.None)]
        internal class NetworkListManager { }

        [ComImport]
        [Guid("DCB00001-570F-4A9B-8D69-199FDBA5723B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface INetworkListManagerEvents
        {
            void ConnectivityChanged(ConnectivityStates newConnectivity);
        }

        [ComImport]
        [Guid("DCB00002-570F-4A9B-8D69-199FDBA5723B")]
        [TypeLibType(TypeLibTypeFlags.FDispatchable)]
        internal interface INetwork
        {
            [return: MarshalAs(UnmanagedType.BStr)]
            string GetName();
            void SetName([MarshalAs(UnmanagedType.BStr)] string szNetworkNewName);
            [return: MarshalAs(UnmanagedType.BStr)]
            string GetDescription();
            void SetDescription([MarshalAs(UnmanagedType.BStr)] string szDescription);
            Guid GetNetworkId();
            DomainType GetDomainType();
            IEnumerable GetNetworkConnections();
            void GetTimeCreatedAndConnected(out uint pdwLowDateTimeCreated, out uint pdwHighDateTimeCreated, out uint pdwLowDateTimeConnected, out uint pdwHighDateTimeConnected);
            bool IsConnectedToInternet { get; }
            bool IsConnected { get; }
            ConnectivityStates GetConnectivity();
            NetworkCategory GetCategory();
            void SetCategory(NetworkCategory pgdAdapterId);
        }

        [ComImport]
        [Guid("DCB00004-570F-4A9B-8D69-199FDBA5723B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface INetworkEvents
        {
            void NetworkAdded(Guid networkId);
            void NetworkDeleted(Guid networkId);
            void NetworkConnectivityChanged(Guid networkId, ConnectivityStates newConnectivity);
            void NetworkPropertyChanged(Guid networkId, ChangedProperties flags);
        }

        [ComImport]
        [Guid("DCB00005-570F-4A9B-8D69-199FDBA5723B")]
        [TypeLibType(TypeLibTypeFlags.FDispatchable)]
        internal interface INetworkConnection
        {
            INetwork GetNetwork();
            bool IsConnectedToInternet { get; }
            bool IsConnected { get; }
            ConnectivityStates GetConnectivity();
            Guid GetConnectionId();
            Guid GetAdapterId();
            DomainType GetDomainType();
        }

        [ComImport]
        [Guid("DCB00007-570F-4A9B-8D69-199FDBA5723B")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface INetworkConnectionEvents
        {
            void NetworkConnectionConnectivityChanged(Guid connectionId, ConnectivityStates newConnectivity);
            void NetworkConnectionPropertyChanged(Guid connectionId, ChangedProperties flags);
        }
    }
}
