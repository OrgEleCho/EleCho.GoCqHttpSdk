namespace NullLib.GoCqHttpSdk.Event
{
    public class CqNoticeFriendRecallEventModel : CqNoticeEventModel
    {
        public override string notice_type => "friend_recall";

        public long user_id { get; set; }
        public long message_id { get; set; }
    }
}
