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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqReplyDataModel(Id, Text, QQ, UnixTime.DateToUnix(Time), Seq));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqReplyDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Text = m.text;
            QQ = m.qq;
            Time = UnixTime.DateFromUnix(m.time);
            Seq = m.seq;
        }
    }

    public class CqReplyDataModel
    {
        internal CqReplyDataModel() { }
        public CqReplyDataModel(string id, string text, long qq, long time, long seq)
        {
            this.id = id;
            this.text = text;
            this.qq = qq;
            this.time = time;
            this.seq = seq;
        }

        public string id { get; set; }
        public string text { get; set; }
        public long qq { get; set; }
        public long time { get; set; }
        public long seq { get; set; }
    }
}
