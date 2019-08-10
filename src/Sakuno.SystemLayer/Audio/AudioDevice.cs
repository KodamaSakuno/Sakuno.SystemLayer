using System.Runtime.InteropServices;

namespace Sakuno.SystemLayer.Audio
{
    public sealed class AudioDevice : DisposableObject
    {
        NativeInterfaces.IMMDevice _device;

        public string Id => _device.GetId();

        public AudioDeviceState State => _device.GetState();

        public string Name { get; }

        internal AudioDevice(NativeInterfaces.IMMDevice device)
        {
            _device = device;

            var properties = _device.OpenPropertyStore(NativeEnums.STGM.STGM_READ);

            try
            {
                var propertyKey = new NativeStructs.PROPERTYKEY(NativeGuids.PKEY_Device_FriendlyName, 14);
                using var propertyVariant = new NativeStructs.PROPVARIANT();

                properties.GetValue(propertyKey, propertyVariant);

                Name = propertyVariant.StringValue;
            }
            finally
            {
                Marshal.ReleaseComObject(properties);
            }
        }

        protected override void DisposeNativeResources() => Marshal.ReleaseComObject(_device);
    }
}
