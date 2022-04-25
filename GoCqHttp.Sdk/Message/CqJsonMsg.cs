using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqJsonMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Json;

        internal CqJsonMsg() { }
        public CqJsonMsg(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public int ResId { get; set; }

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqJsonDataModel(Data, ResId));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqJsonDataModel;
            if (m == null)
                throw new ArgumentException();

            Data = m.data;
            ResId = m.resid;
        }
    }

    public class CqJsonDataModel
    {
        public string data { get; set; }
        public int resid { get; set; }

        internal CqJsonDataModel() { }
        public CqJsonDataModel(string data, int resid)
        {
            this.data = data;
            this.resid = resid;
        }
    }
}
