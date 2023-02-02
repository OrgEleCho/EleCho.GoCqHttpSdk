using EleCho.GoCqHttpSdk.Post;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk
{
    public class CqDevice
    {
        public long AppId { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public string DeviceKind { get; set; } = string.Empty;

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