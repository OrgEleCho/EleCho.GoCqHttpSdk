using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqXmlMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Xml;

        internal CqXmlMsg() { }
        public CqXmlMsg(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public int ResId { get; set; }

        internal override object GetDataModel() => new CqXmlMsgDataModel(Data, ResId.ToString());
        internal override void ReadDataModel(object model)
        {
            var m = model as CqXmlMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Data = m.data;
            ResId = int.Parse(m.resid);
        }
    }
}
