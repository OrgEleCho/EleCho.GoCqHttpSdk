using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Linq;

namespace EleCho.GoCqHttpSdk
{
    public record class CqForwardMessageNode : CqMsg
    {
        public override string Type => Consts.MsgType.Node;

        public long? Id { get; private set; }
        public string? Name { get; private set; }
        public long? QQ { get; private set; }
        public CqMessage? Content { get; private set; }
        public CqMessage? Seq { get; private set; }

        internal CqForwardMessageNode()
        { }

        public CqForwardMessageNode(long id)
        {
            Id = id;
        }

        public CqForwardMessageNode(string name, long qq, CqMessage content)
        {
            Name = name;
            QQ = qq;
            Content = content;
        }

        public CqForwardMessageNode(string name, long qq, CqMessage content, CqMessage seq)
        {
            Name = name;
            QQ = qq;
            Content = content;
            Seq = seq;
        }

        internal override CqMsgDataModel? GetDataModel() =>
            new CqForwardMsgNodeDataModel(Id, Name, QQ,
                Content?.Select(CqMsg.ToModel).ToArray(),
                Seq?.Select(CqMsg.ToModel).ToArray());

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqForwardMsgNodeDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Name = m.name;
            QQ = m.uin;
            Content = m.content == null ? null : new CqMessage(m.content.Select(CqMsg.FromModel));
            Seq = m.seq == null ? null : new CqMessage(m.seq.Select(CqMsg.FromModel));
        }
    }
}