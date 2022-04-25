namespace NullLib.GoCqHttpSdk.Event
{
    public class CqNoticeGroupRecallEventModel : CqNoticeEventModel
    {
        public override string notice_type => "group_recall";
        
        public long group_id { get; set; }
        public long user_id { get; set; }
        public long operator_id { get; set; }
        public long message_id { get; set; }
    }
}
