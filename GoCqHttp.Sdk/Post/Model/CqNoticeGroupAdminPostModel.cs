using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Util;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeGroupAdminPostModel : CqNoticePostModel
    {
        public override string notice_type => Consts.NoticeType.GroupAdmin;

        /// <summary>
        /// <see cref="CqGroupAdminChangeType"/>
        /// </summary>
        public string sub_type { get; set; }

        public long group_id { get; set; }

        public long user_id { get; set; }
    }
}