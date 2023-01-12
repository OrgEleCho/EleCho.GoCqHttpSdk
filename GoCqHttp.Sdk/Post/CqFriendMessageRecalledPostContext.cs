using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqFriendMessageRecalledPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.FriendRecall;
        public long UserId { get; set; }
        public long MessageId { get; set; }

        internal CqFriendMessageRecalledPostContext()
        { }

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