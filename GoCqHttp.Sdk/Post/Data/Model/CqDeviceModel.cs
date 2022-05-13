namespace NullLib.GoCqHttpSdk.Post
{
    internal class CqDeviceModel
    {
        public CqDeviceModel()
        { }

        public CqDeviceModel(CqDevice srcData)
        {
            app_id = srcData.AppId;
            device_name = srcData.DeviceName;
            device_kind = srcData.DeviceKind;
        }

        public long app_id { get; set; }
        public string device_name { get; set; }
        public string device_kind { get; set; }
    }
}