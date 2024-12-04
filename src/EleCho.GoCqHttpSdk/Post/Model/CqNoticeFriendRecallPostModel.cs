#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqNoticeFriendRecallPostModel : CqNoticePostModel
{
    public override string notice_type => "friend_recall";

    public long user_id { get; set; }
    public long message_id { get; set; }
}