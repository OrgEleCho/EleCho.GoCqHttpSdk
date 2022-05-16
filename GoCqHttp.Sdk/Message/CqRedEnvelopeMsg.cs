using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public class CqRedEnvelopeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Redbag;

        internal CqRedEnvelopeMsg()
        { }

        public CqRedEnvelopeMsg(string title) => Title = title;

        public string Title { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqRedEnvelopeMsgDataModel(Title);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqRedEnvelopeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Title = m.title;
        }
    }
}