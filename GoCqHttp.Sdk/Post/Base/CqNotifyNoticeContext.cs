using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqNotifyNoticePostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.Notify;
        public abstract CqNotifyType NotifyType { get; }
    }
}