
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 通知上报上下文
    /// </summary>
    public abstract record class CqNoticePostContext : CqPostContext
    {
        /// <summary>
        /// 上报类型: 通知
        /// </summary>
        public override CqPostType PostType => CqPostType.Notice;

        /// <summary>
        /// 通知类型
        /// </summary>
        public abstract CqNoticeType NoticeType { get; }
    }
}