namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 可处理上报的 Session
    /// </summary>
    public interface ICqPostSession
    {
        /// <summary>
        /// 上报管线
        /// </summary>
        CqPostPipeline PostPipeline { get; }
    }
}