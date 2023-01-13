#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeFriendAddPostModel : CqNoticePostModel
    {
        public override string notice_type => Consts.NoticeType.FriendAdd;

        public long user_id { get; set; }
    }
}