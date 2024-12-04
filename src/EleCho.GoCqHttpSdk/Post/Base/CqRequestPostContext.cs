namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 请求上报上下文
/// </summary>
public abstract record class CqRequestPostContext : CqPostContext
{
    /// <summary>
    /// 上报类型: 请求
    /// </summary>
    public override CqPostType PostType => CqPostType.Request;

    /// <summary>
    /// 请求类型
    /// </summary>
    public abstract CqRequestType RequestType { get; }
}