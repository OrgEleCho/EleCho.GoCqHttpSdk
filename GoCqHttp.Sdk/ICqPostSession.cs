namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 可处理上报的 Session
    /// </summary>
    public interface ICqPostSession
    {
        CqPostPipeline PostPipeline { get; }
    }
}