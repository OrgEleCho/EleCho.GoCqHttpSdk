using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群自身消息上报上下文
    /// </summary>
    public record class CqGroupMessageSentPostContext : CqMessageSentPostContext
    {
        /// <summary>
        /// 消息类型: 群
        /// </summary>
        public override CqMessageType MessageType => CqMessageType.Group;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 匿名对象
        /// </summary>
        public CqAnonymousInfomation? Anonymous { get; set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public CqGroupMessageSender Sender { get; set; } = new CqGroupMessageSender();

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqGroupMessagePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            Anonymous = msgModel.anonymous == null ? null : new CqAnonymousInfomation(msgModel.anonymous);
            Sender = new CqGroupMessageSender(msgModel.sender);
        }
    }
}