namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqNoticeEssenceEventModel : CqNoticeEventModel
    {
        public override string notice_type => "essence";

        /// <summary>
        /// <see cref="CqNoticeEssenceType"/>
        /// </summary>
        public string sub_type { get; set; }
        public long sender_id { get; set; }
        public long operator_id { get; set; }
        public long message_id { get; set; }
    }
}
