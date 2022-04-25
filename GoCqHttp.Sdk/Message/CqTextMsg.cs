using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqTextMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Text;

        public string Text { get; set; }

        internal CqTextMsg() { }
        public CqTextMsg(string text)
        {
            Text = text;
        }

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqTextDataModel(Text));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqTextDataModel;
            if (m == null)
                throw new ArgumentException();

            Text = m.text;
        }
    }

    public class CqTextDataModel
    {
        public string text { get; set; }

        internal CqTextDataModel() { }

        public CqTextDataModel(string text) => this.text = text;
    }
}
