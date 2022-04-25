using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 位置
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqLocationMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Location;

        internal CqLocationMsg() { }
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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqLocationDataModel(Lat, Lon, Title, Content));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqLocationDataModel;
            if (m == null)
                throw new ArgumentException();

            Lat = m.lat;
            Lon = m.lon;
            Title = m.title;
            Content = m.content;
        }
    }

    public class CqLocationDataModel        
    {
        internal CqLocationDataModel() { }
        public CqLocationDataModel(double lat, double lon, string? title, string? content)
        {
            this.lat = lat;
            this.lon = lon;
            this.title = title;
            this.content = content;
        }

        public double lat { get; set; }
        public double lon { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
    }
}
