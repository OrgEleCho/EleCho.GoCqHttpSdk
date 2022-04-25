namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqNoticeGroupAdminEventModel : CqNoticeEventModel
    {
        public string sub_type { get; set; }
        /// <summary>
        /// <see cref="CqNoticeGroupAdminType"/>
        /// </summary>
        public long group_id { get; set; }
        public long user_id { get; set; }
    }
}
