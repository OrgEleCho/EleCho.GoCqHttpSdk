namespace NullLib.GoCqHttpSdk.Post
{
    public class CqDevice
    {
        public long AppId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceKind { get; set; }

        public CqDevice() { }
        internal CqDevice(CqDeviceModel model)
        {
            AppId = model.app_id;
            DeviceName = model.device_name;
            DeviceKind = model.device_kind;
        }
    }
}
