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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqXmlDataModel(Data, ResId));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqXmlDataModel;
            if (m == null)
                throw new ArgumentException();

            Data = m.data;
            ResId = m.resid;
        }
    }

    public class CqXmlDataModel
    {
        public string data { get; set; }
        public int resid { get; set; }

        internal CqXmlDataModel() { }
        public CqXmlDataModel(string data, int resid)
        {
            this.data = data;
            this.resid = resid;
        }
    }
}
