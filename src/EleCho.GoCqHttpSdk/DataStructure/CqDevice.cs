using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Numerics;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 设备信息
    /// </summary>
    public record class CqDevice
    {
        /// <summary>
        /// 应用 ID
        /// </summary>
        public long AppId { get; }

        /// <summary>
        /// 设备名
        /// </summary>
        public string DeviceName { get; } = string.Empty;

        /// <summary>
        /// 设备类型
        /// </summary>
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

        /// <summary>
        /// 实例化设备信息实例
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="deviceName"></param>
        /// <param name="deviceKind"></param>
        public CqDevice(long appId, string deviceName, string deviceKind)
        {
            AppId = appId;
            DeviceName = deviceName;
            DeviceKind = deviceKind;
        }
    }
}