using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal abstract class CqNoticeGroupAdminPostModel : CqNoticePostModel
    {
        public string sub_type { get; set; }

        /// <summary>
        /// <see cref="CqNoticeGroupAdminType"/>
        /// </summary>
        public long group_id { get; set; }

        public long user_id { get; set; }
    }
}