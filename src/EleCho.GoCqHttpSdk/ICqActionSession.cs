namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 可发送 Action 的 Session
    /// </summary>
    public interface ICqActionSession
    {
        /// <summary>
        /// 操作发送
        /// </summary>
        CqActionSender ActionSender { get; }
    }
}