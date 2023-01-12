using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public class CqTtsMsg : CqMsg
    {
        internal CqTtsMsg()
        {
        }

        public CqTtsMsg(string text)
        {
            Text = text;
        }

        public override string Type => Consts.MsgType.TTS;

        public string Text { get; set; }

        internal override CqMsgDataModel GetDataModel()
        {
            return new CqTtsMsgDataModel(Text);
        }

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            if (model is not CqTtsMsgDataModel m)
                throw new ArgumentException();

            Text = m.text;
        }
    }
}