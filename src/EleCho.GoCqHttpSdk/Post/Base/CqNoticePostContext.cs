
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqNoticePostContext : CqPostContext
    {
        public override CqPostType PostType => CqPostType.Notice;
        public abstract CqNoticeType NoticeType { get; }
    }
}