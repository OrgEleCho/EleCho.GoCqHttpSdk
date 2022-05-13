using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post
{
    public abstract class CqNoticePostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Notice;
        public abstract CqNoticeType NoticeType { get; }
    }
}