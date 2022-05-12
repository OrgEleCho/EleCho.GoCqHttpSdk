namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeFriendAddPostModel : CqNoticePostModel
    {
        public override string notice_type => "friend_add";

        public long user_id { get; set; }
    }
}
