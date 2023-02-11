using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk
{
    public record class CqDevice
    {
        public long AppId { get; }
        public string DeviceName { get; } = string.Empty;
        public string DeviceKind { get; } = string.Empty;

        internal CqDevice()
        {
        }

        internal CqDevice(CqDeviceModel model)
        {
            AppId = model.app_id;
            DeviceName = model.device_name;
            DeviceKind = model.device_kind;
        }

        [JsonConstructor]
        public CqDevice(long appId, string deviceName, string deviceKind)
        {
            AppId = appId;
            DeviceName = deviceName;
            DeviceKind = deviceKind;
        }
    }
}