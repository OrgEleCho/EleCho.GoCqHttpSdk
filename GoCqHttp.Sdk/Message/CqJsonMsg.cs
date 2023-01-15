using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public class CqJsonMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Json;

        internal CqJsonMsg()
        { }

        public CqJsonMsg(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
        public int ResId { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqJsonMsgDataModel(Data, ResId);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqJsonMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Data = m.data;
            ResId = m.resid;
        }
    }
}