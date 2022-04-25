namespace NullLib.GoCqHttpSdk.Event
{
    public class CqNoticeFriendAddEventModel : CqNoticeEventModel
    {
        public override string notice_type => "friend_add";

        public long user_id { get; set; }
    }
}
