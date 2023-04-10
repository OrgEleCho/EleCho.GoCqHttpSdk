

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群通知上报上下文
    /// </summary>
    public abstract record class CqNotifyNoticePostContext : CqNoticePostContext
    {
        /// <summary>
        /// 通知类型: 群通知
        /// </summary>
        public override CqNoticeType NoticeType => CqNoticeType.Notify;

        /// <summary>
        /// 群通知类型
        /// </summary>
        public abstract CqNotifyType NotifyType { get; }
    }
}