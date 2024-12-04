using EleCho.GoCqHttpSdk.Action.Sender;
using EleCho.GoCqHttpSdk.Post.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 反向 WebSocket 会话
/// </summary>
public class CqRWsSession : CqSession, ICqActionSession, ICqPostSession, IDisposable
{
    private readonly Uri baseUri;
    private readonly int bufferSize;
    private readonly string? accessToken;
    private readonly bool useApiEndpoint;
    private readonly bool useEventEndpoint;


    private readonly HttpListener listener;

    private readonly List<CqWsSession> connections;
    private readonly List<CqWsSession> apiConnections;
    private readonly List<CqWsSession> eventConnections;

    private readonly CqRWsActionSender actionSender;
    private readonly CqPostPipeline postPipeline;

    private Task? mainLoopTask;

    /// <summary>
    /// 基地址
    /// </summary>
    public Uri BaseUri => baseUri;

    /// <summary>
    /// 访问令牌
    /// </summary>
    public string? AccessToken => accessToken;


    /// <summary>
    /// 正在监听
    /// </summary>
    public bool IsListening => listener.IsListening;

    /// <summary>
    /// 操作发送器
    /// </summary>
    public CqActionSender ActionSender => actionSender;

    /// <summary>
    /// 上报管线
    /// </summary>
    public CqPostPipeline PostPipeline => postPipeline;

    /// <summary>
    /// 连接
    /// </summary>
    public CqRWsSessionConnectionCollection Connections { get; }

    /// <summary>
    /// 仅用于 API 调用的连接
    /// </summary>
    public CqRWsSessionConnectionCollection ApiConnections { get; }

    /// <summary>
    /// 仅用于事件接收的连接
    /// </summary>
    public CqRWsSessionConnectionCollection EventConnections { get; }


    /// <summary>
    /// 当未捕捉的用户异常发生时
    /// </summary>
    public event UnhandledExceptionEventHandler? UnhandledException;


    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CqRWsSession(CqRWsSessionOptions options)
    {
        baseUri = options.BaseUri ?? throw new ArgumentNullException(nameof(options.BaseUri), "You must specify a base uri.");
        bufferSize = options.BufferSize;
        accessToken = options.AccessToken;

        useApiEndpoint = options.UseApiEndPoint;
        useEventEndpoint = options.UseEventEndPoint;

        listener = new HttpListener();
        listener.Prefixes.Add(baseUri.ToString());

        actionSender = new CqRWsActionSender(this);
        postPipeline = new CqPostPipeline();

        connections = [];
        Connections = new CqRWsSessionConnectionCollection(this, connections);

        apiConnections = [];
        ApiConnections = new CqRWsSessionConnectionCollection(this, apiConnections);

        eventConnections = [];
        EventConnections = new CqRWsSessionConnectionCollection(this, eventConnections);
    }

    private async Task HttpListenerLoopAsync()
    {
        string accessTokenHeaderValue =
            $"Bearer {accessToken}";

        while (listener.IsListening)
        {
            var context = await listener.GetContextAsync();

            if (accessToken != null &&
                !accessTokenHeaderValue.Equals(context.Request.Headers.Get("Authorization"), StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                continue;
            }

            if (context.Request.IsWebSocketRequest)
            {
                var wsContext = await context.AcceptWebSocketAsync(null);
                var ws = wsContext.WebSocket;

                if (wsContext.RequestUri.AbsolutePath.Equals("/", StringComparison.OrdinalIgnoreCase))
                    _ = ConnectionLoopAsync(wsContext, ws);
                else if (useApiEndpoint && wsContext.RequestUri.AbsolutePath.Equals("/api", StringComparison.OrdinalIgnoreCase))
                    _ = ApiConnectionLoopAsync(wsContext, ws);
                else if (useEventEndpoint && wsContext.RequestUri.AbsolutePath.Equals("/event", StringComparison.OrdinalIgnoreCase))
                    _ = EventConnectionLoopAsync(wsContext, ws);
                else
                    await ws.CloseOutputAsync(WebSocketCloseStatus.EndpointUnavailable, null, default);
            }
        }
    }


    private async Task ConnectionLoopAsync(WebSocketContext context, WebSocket ws)
    {
        CqWsSession wsSession = new CqWsSession(ws, context.RequestUri, accessToken, bufferSize);
        wsSession.PostPipeline.Use(ConnectionPostMiddleware);
        wsSession.UnhandledException += WsSession_UnhandledException;

        connections.Add(wsSession);
        await wsSession.RunAsync();
        connections.Remove(wsSession);

        wsSession.UnhandledException -= WsSession_UnhandledException;
    }

    private async Task ApiConnectionLoopAsync(WebSocketContext context, WebSocket ws)
    {
        CqWsSession wsSession = new CqWsSession(ws, context.RequestUri, accessToken, bufferSize);

        apiConnections.Add(wsSession);
        await wsSession.RunAsync();
        apiConnections.Remove(wsSession);
    }

    private async Task EventConnectionLoopAsync(WebSocketContext context, WebSocket ws)
    {
        CqWsSession wsSession = new CqWsSession(ws, context.RequestUri, accessToken, bufferSize);
        wsSession.PostPipeline.Use(ConnectionPostMiddleware);
        wsSession.UnhandledException += WsSession_UnhandledException;

        eventConnections.Add(wsSession);
        await wsSession.RunAsync();
        eventConnections.Remove(wsSession);

        wsSession.UnhandledException -= WsSession_UnhandledException;
    }

    private void WsSession_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        UnhandledException?.Invoke(sender, e);
    }

    private async Task ConnectionPostMiddleware(CqPostContext context, Func<Task> next)
    {
        await PostPipeline.ExecuteAsync(context, default);
        await next.Invoke();
    }

    /// <summary>
    /// 异步启动
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话已经启动</exception>
    public Task StartAsync()
    {
        if (listener.IsListening)
            throw new InvalidOperationException("Session is already started");

        listener.Start();

        mainLoopTask =
            HttpListenerLoopAsync();

        return Task.CompletedTask;
    }

    /// <summary>
    /// 异步停止
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话没有启动</exception>
    public Task StopAsync()
    {
        if (!listener.IsListening)
            throw new InvalidOperationException("Session is not started yet");

        listener.Stop();

        return Task.CompletedTask;
    }


    /// <summary>
    /// 异步等待关闭
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">会话没有启动</exception>
    public async Task WaitForShutdownAsync()
    {
        if (mainLoopTask == null)
            throw new InvalidOperationException("Session is not started yet");

        await mainLoopTask;
    }

    /// <summary>
    /// 异步运行 (异步启动并等待关闭)
    /// </summary>
    /// <returns></returns>
    public async Task RunAsync()
    {
        await StartAsync();
        await WaitForShutdownAsync();
    }

    /// <summary>
    /// 同步启动
    /// </summary>
    public void Start() => StartAsync().Wait();

    /// <summary>
    /// 同步停止
    /// </summary>
    public void Stop() => StopAsync().Wait();

    /// <summary>
    /// 同步运行
    /// </summary>
    public void Run() => RunAsync().Wait();

    /// <summary>
    /// 同步等待关闭
    /// </summary>
    public void WaitForShutdown() => WaitForShutdownAsync().Wait();


    bool disposed = false;

    /// <summary>
    /// 释放资源
    /// </summary>
    public void Dispose()
    {
        if (disposed)
            return;

        listener.Close();

        GC.SuppressFinalize(this);
        disposed = true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <remarks>
    /// 实例化
    /// </remarks>
    /// <param name="owner"></param>
    /// <param name="storage"></param>
    public class CqRWsSessionConnectionCollection(CqRWsSession owner, IList<CqWsSession> storage) : IReadOnlyList<CqWsSession>
    {
        private readonly IList<CqWsSession> storage = storage;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public CqWsSession this[int index] => storage[index];

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public int Count => storage.Count;

        /// <summary>
        /// Owner
        /// </summary>
        public CqRWsSession Owner { get; } = owner;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerator<CqWsSession> GetEnumerator() => storage.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => storage.GetEnumerator();
    }
}