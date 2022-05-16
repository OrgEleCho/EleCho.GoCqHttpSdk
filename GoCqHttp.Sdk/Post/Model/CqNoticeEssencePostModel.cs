using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeEssencePostModel : CqNoticePostModel
    {
        public override string notice_type => "essence";

        /// <summary>
        /// <see cref="CqEssenceChangeType"/>
        /// </summary>
        public string sub_type { get; set; }

        public long sender_id { get; set; }
        public long operator_id { get; set; }
        public long message_id { get; set; }
    }
}