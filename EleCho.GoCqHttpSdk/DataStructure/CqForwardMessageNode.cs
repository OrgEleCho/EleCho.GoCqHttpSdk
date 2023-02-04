using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqForwardMessageNode : CqMsg
    {
        public override string Type => Consts.MsgType.Node;

        public long? Id { get; private set; }
        public string? Name { get; private set; }
        public long? QQ { get; private set; }
        public CqMsg[]? Content { get; private set; }
        public CqMsg[]? Seq { get; private set; }

        internal CqForwardMessageNode()
        { }

        public CqForwardMessageNode(long id)
        {
            Id = id;
        }

        public CqForwardMessageNode(string name, long qq, params CqMsg[] content)
        {
            Name = name;
            QQ = qq;
            Content = content;
        }

        public CqForwardMessageNode(string name, long qq, CqMsg[] content, CqMsg[] seq)
        {
            Name = name;
            QQ = qq;
            Content = content;
            Seq = seq;
        }

        internal override CqMsgDataModel? GetDataModel() =>
            new CqForwardMsgNodeDataModel(Id, Name, QQ,
                Array.ConvertAll(Content ?? Array.Empty<CqMsg>(), ToModel),
                Array.ConvertAll(Seq ?? Array.Empty<CqMsg>(), ToModel));

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqForwardMsgNodeDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Name = m.name;
            QQ = m.uin;
            Content = Array.ConvertAll(m.content ?? Array.Empty<CqMsgModel>(), FromModel);
            Seq = Array.ConvertAll(m.seq ?? Array.Empty<CqMsgModel>(), FromModel);
        }
    }
}