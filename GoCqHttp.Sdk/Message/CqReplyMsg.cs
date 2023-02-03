using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public record class CqReplyMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Reply;

#pragma warning disable CS8618

        internal CqReplyMsg()
        { }

#pragma warning restore CS8618

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

        internal override CqMsgDataModel? GetDataModel() => new CqReplyMsgDataModel(Id, Text, QQ, UnixTime.DateToUnix(Time), Seq);

        internal override void ReadDataModel(CqMsgDataModel? model)
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