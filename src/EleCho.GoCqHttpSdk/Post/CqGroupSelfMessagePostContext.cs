using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群消息上报上下文
    /// </summary>
    public record class CqGroupSelfMessagePostContext : CqSelfMessagePostContext, IGroupPostContext
    {
        /// <summary>
        /// 消息类型: 群
        /// </summary>
        public override CqMessageType MessageType => CqMessageType.Group;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; internal set; }

        /// <summary>
        /// 匿名对象
        /// </summary>
        public CqAnonymousInfomation? Anonymous { get; internal set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public CqGroupMessageSender Sender { get; internal set; } = new CqGroupMessageSender();

        internal CqGroupSelfMessagePostContext() { }

        /// <summary>
        /// 快速操作
        /// </summary>
        public CqGroupMessagePostQuickOperation QuickOperation { get; }
            = new CqGroupMessagePostQuickOperation();

        internal override object? QuickOperationModel => QuickOperation.GetModel();
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqGroupSelfMessagePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            Anonymous = msgModel.anonymous == null ? null : new CqAnonymousInfomation(msgModel.anonymous);
            Sender = new CqGroupMessageSender(msgModel.sender);
        }
    }
}