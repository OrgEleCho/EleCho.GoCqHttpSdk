using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal abstract class CqNoticeGroupAdminPostModel : CqNoticePostModel
    {
        /// <summary>
        /// <see cref="CqGroupAdminChangeType"/>
        /// </summary>
        public string sub_type { get; set; }

        public long group_id { get; set; }

        public long user_id { get; set; }
    }
}