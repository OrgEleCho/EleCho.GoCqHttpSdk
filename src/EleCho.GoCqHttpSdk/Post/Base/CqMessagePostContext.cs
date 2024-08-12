using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post.Model;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 消息上报上下文
    /// </summary>
    public abstract record class CqMessagePostContext : CqPostContext
    {
        /// <summary>
        /// 上报类型: 消息
        /// </summary>
        public override CqPostType PostType => CqPostType.Message;

        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract CqMessageType MessageType { get; }

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; internal set; }

        /// <summary>
        /// 用户 ID
        /// </summary>
        public long UserId { get; internal set; }

        /// <summary>
        /// 消息实例
        /// </summary>
        public CqMessage Message { get; internal set; } = new CqMessage(0);

        /// <summary>
        /// 原始消息 (CQ 码)
        /// </summary>
        public string RawMessage { get; internal set; } = string.Empty;

        /// <summary>
        /// 字体
        /// </summary>
        public int Font { get; internal set; }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMessagePostModel msgModel)
                return;

            MessageId = msgModel.message_id;
            UserId = msgModel.user_id;
            Message = new CqMessage(msgModel.message.Select(CqMsg.FromModel));
            RawMessage = msgModel.raw_message;
            Font = msgModel.font;
        }
    }
}