using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqFriendAddedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.FriendAdd;

        public long UserId { get; set; }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeFriendAddPostModel noticeModel)
                return;

            UserId = noticeModel.user_id;
        }
    }
}