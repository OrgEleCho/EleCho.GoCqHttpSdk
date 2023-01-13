#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeFriendRecallPostModel : CqNoticePostModel
    {
        public override string notice_type => "friend_recall";

        public long user_id { get; set; }
        public long message_id { get; set; }
    }
}