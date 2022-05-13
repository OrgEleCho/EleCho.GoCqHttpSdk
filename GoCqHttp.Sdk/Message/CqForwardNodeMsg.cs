using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqForwardNodeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Node;

        public int? Id { get; set; }
        public string? Name { get; set; }
        public long? QQ { get; set; }
        public CqMsg[]? Content { get; set; }
        public CqMsg[]? Seq { get; set; }

        internal CqForwardNodeMsg()
        { }

        public CqForwardNodeMsg(int id)
        {
            Id = id;
        }

        public CqForwardNodeMsg(string name, long qq, CqMsg[] content)
        {
            Name = name;
            QQ = qq;
            Content = content;
        }

        public CqForwardNodeMsg(string name, long qq, CqMsg[] content, CqMsg[] seq)
        {
            Name = name;
            QQ = qq;
            Content = content;
            Seq = seq;
        }

        internal override CqMsgDataModel GetDataModel() => new CqForwardNodeMsgDataModel(Id, Name, QQ, Content, Seq);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqForwardNodeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Name = m.name;
            QQ = m.uin;
            Content = m.content;
            Seq = m.seq;
        }
    }
}