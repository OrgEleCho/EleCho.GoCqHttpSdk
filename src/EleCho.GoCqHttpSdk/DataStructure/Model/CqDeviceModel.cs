using System.Numerics;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model
{
    internal record class CqDeviceModel
    {
        public CqDeviceModel(CqDevice srcData)
        {
            app_id = srcData.AppId;
            device_name = srcData.DeviceName;
            device_kind = srcData.DeviceKind;
        }

        [JsonConstructor]
        public CqDeviceModel(long app_id, string device_name, string device_kind)
        {
            this.app_id = app_id;
            this.device_name = device_name;
            this.device_kind = device_kind;
        }

        public long app_id { get; set; }
        public string device_name { get; set; }
        public string device_kind { get; set; }
    }
}