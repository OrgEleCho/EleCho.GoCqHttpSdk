using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public record class CqXmlMsg : CqMsg
    {
        public override string MsgType => Consts.MsgType.Xml;

        internal CqXmlMsg()
        { }

        public CqXmlMsg(string data)
        {
            Data = data;
        }

        public string Data { get; set; } = string.Empty;
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