namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 上报类型
    /// </summary>
    public enum CqPostType
    {
        /// <summary>
        /// 元事件
        /// </summary>
        MetaEvent,

        /// <summary>
        /// 请求
        /// </summary>
        Request,

        /// <summary>
        /// 消息
        /// </summary>
        Message,

        /// <summary>
        /// 自身消息
        /// </summary>
        MessageSent,

        /// <summary>
        /// 通知
        /// </summary>
        Notice,
    }
}