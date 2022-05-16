using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 位置
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqLocationMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Location;

        internal CqLocationMsg()
        { }

        public CqLocationMsg(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// 发送时可选, 标题
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// 发送时可选, 内容描述
        /// </summary>
        public string? Content { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqLocationMsgDataModel(Lat, Lon, Title, Content);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqLocationMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Lat = m.lat;
            Lon = m.lon;
            Title = m.title;
            Content = m.content;
        }
    }
}