using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeGroupBanPostModel : CqNoticePostModel
    {
        public override string notice_type => "group_ban";

        /// <summary>
        /// <see cref="CqGroupBanChangeType"/>
        /// </summary>
        public string sub_type { get; set; }

        public long group_id { get; set; }
        public long operator_id { get; set; }
        public long user_id { get; set; }
        public long duration { get; set; }
    }
}