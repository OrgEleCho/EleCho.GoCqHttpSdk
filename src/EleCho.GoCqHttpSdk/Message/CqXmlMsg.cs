using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// XML 消息段
    /// </summary>
    public record class CqXmlMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: XML 消息
        /// </summary>
        public override string MsgType => Consts.MsgType.Xml;

        internal CqXmlMsg()
        { }

        /// <summary>
        /// 实例化 XML 消息段
        /// </summary>
        /// <param name="data"></param>
        public CqXmlMsg(string data)
        {
            Data = data;
        }

        /// <summary>
        /// XML 数据内容
        /// </summary>
        public string Data { get; set; } = string.Empty;

        /// <summary>
        /// 可能为空, 或空字符串 (官方也不说这干啥用的 (?
        /// </summary>
        public int? ResId { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqXmlMsgDataModel(Data, ResId?.ToString());

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqXmlMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Data = m.data;

            if (!string.IsNullOrWhiteSpace(m.resid) &&
                int.TryParse(m.resid, out int _resid))
                ResId = _resid;
        }
    }
}