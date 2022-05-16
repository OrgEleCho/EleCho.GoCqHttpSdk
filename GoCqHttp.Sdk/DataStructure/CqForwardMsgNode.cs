using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqForwardMsgNode : CqMsg
    {
        public override string Type => Consts.MsgType.Node;

        public int? Id { get; set; }
        public string? Name { get; set; }
        public long? QQ { get; set; }
        public CqMsg[]? Content { get; set; }
        public CqMsg[]? Seq { get; set; }

        internal CqForwardMsgNode()
        { }

        public CqForwardMsgNode(int id)
        {
            Id = id;
        }

        public CqForwardMsgNode(string name, long qq, params CqMsg[] content)
        {
            Name = name;
            QQ = qq;
            Content = content;
        }

        public CqForwardMsgNode(string name, long qq, CqMsg[] content, CqMsg[] seq)
        {
            Name = name;
            QQ = qq;
            Content = content;
            Seq = seq;
        }

        internal override CqMsgDataModel GetDataModel() =>
            new CqForwardMsgNodeDataModel(Id, Name, QQ,
                Array.ConvertAll(Content ?? Array.Empty<CqMsg>(), ToModel),
                Array.ConvertAll(Seq ?? Array.Empty<CqMsg>(), ToModel));

        internal override void ReadDataModel(CqMsgDataModel model)
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