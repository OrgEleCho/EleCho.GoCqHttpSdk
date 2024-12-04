using EleCho.GoCqHttpSdk.Action.Sender;
using System;
using System.Net.Http;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 正向 HTTP 会话.
/// 可用来发送 Action
/// </summary>
public class CqHttpSession : CqSession, ICqActionSession, IDisposable
{
    private readonly CqHttpActionSender actionSender;

    /// <summary>
    /// 基础客户端
    /// </summary>
    public HttpClient BaseClient { get; }

    /// <summary>
    /// 操作发送器
    /// </summary>
    public CqActionSender ActionSender => actionSender;

    /// <summary>
    /// 实例化 CQ HTTP 会话
    /// </summary>
    /// <param name="options"></param>
    public CqHttpSession(CqHttpSessionOptions options)
    {
        BaseClient = new HttpClient
        {
            BaseAddress = options.BaseUri
        };
        if (options.AccessToken != null)
            BaseClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.AccessToken}");

        actionSender = new CqHttpActionSender(BaseClient);
    }

    readonly bool disposed = false;
    
    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
        if (disposed)
            return;

        BaseClient.Dispose();
    }
}