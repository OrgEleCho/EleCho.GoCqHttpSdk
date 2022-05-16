namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 可发送 Action 的 Session
    /// </summary>
    public interface ICqActionSession
    {
        CqActionSender ActionSender { get; }
    }
}