namespace NullLib.GoCqHttpSdk.Event
{
    public class CqNoticeLuckyKingEventModel : CqNoticeNotifyEventModel
    {
        public override string sub_type => "lucky_king";

        public long group_id { get; set; }
        public long user_id { get; set; }
        public long target_id { get; set; }
    }
}
