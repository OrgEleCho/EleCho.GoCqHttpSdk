
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 好友消息撤回
    /// </summary>
    public class CqFriendMessageRecalledPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.FriendRecall;
        public long UserId { get; set; }
        public long MessageId { get; set; }

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