using System;
using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Net
{
    public class Network : DisposableObject
    {
        NativeInterfaces.INetwork _network;

        public string Name
        {
            get => _network.GetName();
            set => _network.SetName(value);
        }
        public string Description
        {
            get => _network.GetDescription();
            set => _network.SetDescription(value);
        }

        public Guid ID => _network.GetNetworkId();

        public DomainType DomainType => _network.GetDomainType();

        public ConnectivityStates Connectivity => _network.GetConnectivity();

        public bool IsConnected => _network.IsConnected;
        public bool IsConnectedToInternet => _network.IsConnectedToInternet;

        public NetworkCategory Category
        {
            get => _network.GetCategory();
            set => _network.SetCategory(value);
        }

        public bool IsCaptivePortalDectected
        {
            get
            {
                string propertyName;

                var connectivity = Connectivity;
                if ((connectivity & ConnectivityStates.IPv4Internet) != 0 || (connectivity & ConnectivityStates.IPv4LocalNetwork) != 0)
                    propertyName = "NA_InternetConnectivityV4";
                else if ((connectivity & ConnectivityStates.IPv6Internet) != 0 || (connectivity & ConnectivityStates.IPv6LocalNetwork) != 0)
                    propertyName = "NA_InternetConnectivityV6";
                else
                    return false;

                using (var propertyVariant = new NativeStructs.PROPVARIANT())
                {
                    ((NativeInterfaces.IPropertyBag)_network).Read(propertyName, propertyVariant);

                    return ((NativeEnums.NLM_INTERNET_CONNECTIVITY)propertyVariant.Int32Value & NativeEnums.NLM_INTERNET_CONNECTIVITY.NLM_INTERNET_CONNECTIVITY_WEBHIJACK) != 0;
                }
            }
        }

        internal Network(NativeInterfaces.INetwork network) => _network = network;

        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_network);
    }
}
