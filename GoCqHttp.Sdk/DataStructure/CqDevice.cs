using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqDevice
    {
        public long AppId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceKind { get; set; }
        
        internal CqDevice(CqDeviceModel model)
        {
            AppId = model.app_id;
            DeviceName = model.device_name;
            DeviceKind = model.device_kind;
        }

        public CqDevice(long appId, string deviceName, string deviceKind)
        {
            AppId = appId;
            DeviceName = deviceName;
            DeviceKind = deviceKind;
        }
    }
}