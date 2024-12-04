using System;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 反向 WebSocket 会话选项
/// </summary>
public struct CqRWsSessionOptions
{
    /// <summary>
    /// 创建结构
    /// </summary>
    public CqRWsSessionOptions()
    {
    }

    /// <summary>
    /// 基地址
    /// </summary>
    public Uri? BaseUri { get; set; }

    /// <summary>
    /// 使用 /api 接入点
    /// </summary>
    public bool UseApiEndPoint { get; set; }

    /// <summary>
    /// 使用 /event 接入点
    /// </summary>
    public bool UseEventEndPoint { get; set; }

    /// <summary>
    /// 访问令牌 (鉴权用)
    /// </summary>
    public string? AccessToken { get; set; }


    /// <summary>
    /// 缓冲区大小
    /// </summary>
    public int BufferSize { get; set; } = 1024;
}