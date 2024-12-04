 using System;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// HTTP 会话选项
/// </summary>
public struct CqHttpSessionOptions
{
    /// <summary>
    /// 基地址
    /// </summary>
    public Uri BaseUri { get; set; }

    /// <summary>
    /// 访问令牌
    /// </summary>
    public string? AccessToken { get; set; }
}