

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 元事件上报上下文
    /// </summary>
    public abstract record class CqMetaEventPostContext : CqPostContext
    {
        /// <summary>
        /// 上报类型: 元事件
        /// </summary>
        public override CqPostType PostType => CqPostType.MetaEvent;

        /// <summary>
        /// 元事件类型
        /// </summary>
        public abstract CqMetaEventType MetaEventType { get; }
    }
}