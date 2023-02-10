namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 操作状态码
    /// </summary>
    public enum CqActionStatus
    {
        /// <summary>
        /// 调用成功
        /// </summary>
        Okay,
        /// <summary>
        /// 调用已经提交异步处理, 此时 retcode 为 1, 具体 api 调用是否成功无法得知
        /// </summary>
        Async,
        /// <summary>
        /// 调用失败
        /// </summary>
        Failed,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = -1
    }
}