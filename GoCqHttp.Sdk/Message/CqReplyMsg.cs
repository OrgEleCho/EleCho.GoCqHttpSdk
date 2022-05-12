using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqReplyMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Reply;

        internal CqReplyMsg() { }
        public CqReplyMsg(string id, string text, long qq, long seq)
        {
            Id = id;
            Text = text;
            QQ = qq;
            Seq = seq;

            Time = DateTime.Now;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public long QQ { get; set; }
        public DateTime Time { get; set; }
        public long Seq { get; set; }

        internal override object GetDataModel() => new CqReplyMsgDataModel(Id, Text, QQ, UnixTime.DateToUnix(Time), Seq);
        internal override void ReadDataModel(object model)
        {
            var m = model as CqReplyMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Text = m.text;
            QQ = m.qq;
            Time = UnixTime.DateFromUnix(m.time);
            Seq = m.seq;
        }
    }
}
