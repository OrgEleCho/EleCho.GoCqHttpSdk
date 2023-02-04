using System;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action.Invoker;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 正向 WebSocket 会话
    /// 可处理上报, 以及发送 Action
    /// </summary>
    public class CqWsSession : CqSession, ICqPostSession, ICqActionSession, IDisposable
    {
        /// <summary>
        /// 基地址
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string? AccessToken { get; }

        // 主循环线程
        private Task? mainLoopTask;
        private Task? standaloneActionLoopTask;

        // 三个接入点的套接字
        private ClientWebSocket? webSocketClient;

        private ClientWebSocket? apiWebSocketClient;
        private ClientWebSocket? eventWebSocketClient;

        /// <summary>
        /// 已连接
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// 缓冲区大小
        /// </summary>
        public int BufferSize { get; set; } = 1024;

        // 用来发送 API 请求
        private readonly CqWsActionSender actionSender;

        // 用来处理 post 上报事件
        private readonly CqPostPipeline postPipeline;

        /// <summary>
        /// 操作发送器 (用来调用 Go-CqHttp 的 API)
        /// </summary>
        public CqActionSender ActionSender => actionSender;

        /// <summary>
        /// 上报管线 (用来接收 Go-CqHttp 提供的上报数据)
        /// </summary>
        public CqPostPipeline PostPipeline => postPipeline;


        /// <summary>
        /// 创建 WebSocket 会话的新实例
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CqWsSession(CqWsSessionOptions options)
        {
            if (options.BaseUri == null)
                throw new ArgumentNullException(nameof(options.BaseUri), "BaseUri can't be null");

            // 设定基础地址和访问令牌
            BaseUri = options.BaseUri;
            AccessToken = options.AccessToken;
            BufferSize = options.BufferSize;

            // 如果使用 api 接入点, 那么则初始化 api 套接字
            if (options.UseApiEndPoint)
                apiWebSocketClient = new ClientWebSocket();

            // 如果使用事件接入点, 那么则初始化事件套接字
            if (options.UseEventEndPoint)
                eventWebSocketClient = new ClientWebSocket();

            // 如果任何一个没有被初始化, 则初始化根套接字
            if (eventWebSocketClient == null || apiWebSocketClient == null)
                webSocketClient = new ClientWebSocket();

            // 初始化 action 发送器 和 post 管道
            actionSender = new CqWsActionSender(this, apiWebSocketClient ?? webSocketClient ?? throw new InvalidOperationException("This would never happened"));
            postPipeline = new CqPostPipeline();
        }

        internal async Task ProcPostModelAsync(CqPostModel postModel)
        {
            CqPostContext? postContext = CqPostContext.FromModel(postModel);
            postContext?.SetSession(this);

            // 如果 post 上下文不为空, 则使用 PostPipeline 处理该事件
            if (postContext != null)
            {
                await postPipeline.ExecuteAsync(postContext);

                if (postContext.QuickOperationModel is object quickActionModel)
                    await ActionSender.HandleQuickAction(postModel, quickActionModel);
            }

        }

        /// <summary>
        /// 处理 WebSocket 数据
        /// </summary>
        /// <param name="wsDataModel"></param>
        /// <returns></returns>
        private async Task ProcWsDataAsync(CqWsDataModel? wsDataModel)
        {
            // 如果是 post 上报
            if (wsDataModel is CqPostModel postModel)
            {
                await ProcPostModelAsync(postModel);
            }
            // 否则如果是 action 请求响应
            else if (wsDataModel is CqActionResultRaw actionResultRaw)
            {
                // 将请求放入 ActionSender 进行处理
                actionSender.PutActionResult(actionResultRaw);
            }
        }

        /// <summary>
        /// WebSocket 循环
        /// </summary>
        /// <returns></returns>
        private async Task WebSocketLoop(WebSocket webSocket)
        {
            // 初始化缓冲区
            byte[] buffer = new byte[BufferSize];
            MemoryStream ms = new MemoryStream();
            while (!disposed)
            {
                IsConnected = webSocket.State == WebSocketState.Open;

                if (!IsConnected)
                {
                    return;
                }

                try
                {
                    // 重置内存流
                    ms.SetLength(0);
                    // 读取一个消息
                    await webSocket.ReadMessageAsync(ms, buffer, default);
                }
                catch
                {
                    continue;
                    // ignore error
                }

                // 在发布模式下套一层 try 防止消息循环中断
#if RELEASE
                try  // 直接捕捉 JSON 反序列化异常
                {
#endif
                    // 反序列化为 WebSocket 数据 (自己抽的类
                    string json = GlobalConfig.TextEncoding.GetString(ms.ToArray());
                    CqWsDataModel? wsDataModel = JsonSerializer.Deserialize<CqWsDataModel>(json, JsonHelper.Options);

                    // 处理 WebSocket 数据
                    await ProcWsDataAsync(wsDataModel);

#if DEBUG
                if (wsDataModel is not CqPostModel)
                    Console.WriteLine($"Received: {json}");
#endif
#if RELEASE
                }
                catch (JsonException)
                {
                    // 忽略 JSON 反序列化异常
                }
#endif
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        private async Task ConnectAsync()
        {
            string accessTokenHeaderValue = $"Bearer {AccessToken}";

            // 如果 api 套接字不为空, 则连接 api 套接字
            if (apiWebSocketClient != null)
            {
                if (apiWebSocketClient.State == WebSocketState.Open)
                    return;

                if (AccessToken is not null) apiWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await apiWebSocketClient.ConnectAsync(new Uri(BaseUri, "api"), default);
            }

            // 如果事件套接字不为空, 则连接事件套接字
            if (eventWebSocketClient != null)
            {
                if (eventWebSocketClient.State == WebSocketState.Open)
                    return;

                if (AccessToken is not null) eventWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await eventWebSocketClient.ConnectAsync(new Uri(BaseUri, "event"), default);
            }

            // 如果任意一个为空且基础套接字部不为空, 则连接基础套接字
            if ((apiWebSocketClient == null || eventWebSocketClient == null) && webSocketClient != null)
            {
                if (webSocketClient.State == WebSocketState.Open)
                    return;

                if (AccessToken is not null) webSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await webSocketClient.ConnectAsync(BaseUri, default);
            }

            // 已连接设定为 true
            IsConnected = true;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        private async Task CloseAsync()
        {
            // 关闭已连接的套接字
            if (apiWebSocketClient != null)
                await apiWebSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
            if (eventWebSocketClient != null)
                await eventWebSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
            if (webSocketClient != null)
                await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);

            IsConnected = false;
        }

        /// <summary>
        /// 异步启动会话 (连接并开启主循环)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">会话已经启动了</exception>
        public async Task StartAsync()
        {
            if (mainLoopTask != null)
                throw new InvalidOperationException("Session is already started");

            // 连接所需要的套接字
            await ConnectAsync();

            // 首先一定会有一个主循环, 这个主循环可能是通用的套接字, 也可能是单独的上报套接字 (如果使用单独的 API 和上报套接字, 那么主套接字是空的, 所以会 fallback 到事件套接字)
            mainLoopTask = WebSocketLoop(webSocketClient ?? eventWebSocketClient ?? throw new InvalidOperationException("This would never happened"));

            // 当使用单独的 API 套接字的时候, 我们需要监听 API 套接字
            if (apiWebSocketClient != null)
                standaloneActionLoopTask = WebSocketLoop(apiWebSocketClient);
        }

        /// <summary>
        /// 启动会话 (异步方法的包装)
        /// </summary>
        public void Start()
        {
            StartAsync().Wait();
        }

        /// <summary>
        /// 异步等待会话关闭 (等待主循环结束)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">会话还没启动</exception>
        public async Task WaitForShutdownAsync()
        {
            if (mainLoopTask == null)
                throw new InvalidOperationException("Session is not started yet");

            await mainLoopTask;
        }

        /// <summary>
        /// 同步等待关闭 (异步方法的包装)
        /// </summary>
        public void WaitForShutdown()
        {
            WaitForShutdownAsync().Wait();
        }

        /// <summary>
        /// 异步运行会话 (启动并等待关闭)
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            await StartAsync();
            await WaitForShutdownAsync();
        }

        /// <summary>
        /// 同步运行会话 (异步方法的包装)
        /// </summary>
        public void Run()
        {
            RunAsync().Wait();
        }

        /// <summary>
        /// 异步关闭会话 (断开连接并终止主循环)
        /// </summary>
        /// <returns></returns>
        public async Task StopAsync()
        {
            await CloseAsync();
            mainLoopTask = null;
        }

        /// <summary>
        /// 同步关闭会话 (异步方法的包装)
        /// </summary>
        public void Stop()
        {
            StopAsync().Wait();
        }


        private bool disposed = false;
        public void Dispose()
        {
            if (disposed)
                return;

            apiWebSocketClient?.Dispose();
            eventWebSocketClient?.Dispose();
            webSocketClient?.Dispose();
        }
    }
}