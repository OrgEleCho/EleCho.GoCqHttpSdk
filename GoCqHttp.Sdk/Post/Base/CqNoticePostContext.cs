using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqNoticePostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Notice;
        public abstract CqNoticeType NoticeType { get; }
    }
}