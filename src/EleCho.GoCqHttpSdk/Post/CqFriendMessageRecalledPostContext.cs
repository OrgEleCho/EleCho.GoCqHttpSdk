
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 好友消息撤回上报上下文
    /// </summary>
    public record class CqFriendMessageRecalledPostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 好友消息撤回
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.FriendRecall;

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; internal set; }

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; internal set; }

        internal CqFriendMessageRecalledPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeFriendRecallPostModel postModel)
                return;

            UserId = postModel.user_id;
            MessageId = postModel.message_id;
        }
    }
}