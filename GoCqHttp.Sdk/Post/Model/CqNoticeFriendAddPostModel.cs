using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeFriendAddPostModel : CqNoticePostModel
    {
        public override string notice_type => Consts.NoticeType.FriendAdd;

        public long user_id { get; set; }
    }
}