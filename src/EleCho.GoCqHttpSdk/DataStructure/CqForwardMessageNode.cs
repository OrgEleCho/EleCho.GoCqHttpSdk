using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Linq;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 转发消息节点
    /// </summary>
    public record class CqForwardMessageNode : CqMsg
    {
        /// <summary>
        /// 消息类型: 节点
        /// </summary>
        public override string MsgType => Consts.MsgType.Node;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long? Id { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; private set; }

        /// <summary>
        /// QQ 号
        /// </summary>
        public long? UserId { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public CqMessage? Content { get; private set; }

        /// <summary>
        /// 暂时不确定
        /// </summary>
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
            UserId = qq;
            Content = content;
        }

        public CqForwardMessageNode(string name, long qq, CqMessage content, CqMessage seq)
        {
            Name = name;
            UserId = qq;
            Content = content;
            Seq = seq;
        }

        internal override CqMsgDataModel? GetDataModel() =>
            new CqForwardMsgNodeDataModel(Id, Name, UserId,
                Content?.Select(CqMsg.ToModel).ToArray(),
                Seq?.Select(CqMsg.ToModel).ToArray());

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqForwardMsgNodeDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Name = m.name;
            UserId = m.uin;
            Content = m.content == null ? null : new CqMessage(m.content.Select(CqMsg.FromModel));
            Seq = m.seq == null ? null : new CqMessage(m.seq.Select(CqMsg.FromModel));
        }
    }
}