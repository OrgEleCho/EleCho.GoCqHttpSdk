using NullLib.GoCqHttpSdk.Message.DataModel;
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

        internal override object GetDataModel() => new CqTextMsgDataModel(Text);
        internal override void ReadDataModel(object model)
        {
            var m = model as CqTextMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Text = m.text;
        }
    }
}
