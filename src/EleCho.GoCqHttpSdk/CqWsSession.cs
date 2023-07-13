using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action.Sender;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System.Diagnostics;

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
        private Task? mainPostLoopTask;
        private Task? standaloneActionLoopTask;

        // 三个接入点的套接字
        private WebSocket? webSocket;

        private WebSocket? apiWebSocket;
        private WebSocket? eventWebSocket;

        private ConcurrentQueue<CqPostModel> postQueue;

        /// <summary>
        /// 已连接
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// 缓冲区大小
        /// </summary>
        public int BufferSize { get; set; } = 1024;

        // 用来发送 API 请求
        private CqWsActionSender actionSender;

        // 用来处理 post 上报事件
        private CqPostPipeline postPipeline;

        /// <summary>
        /// 操作发送器 (用来调用 Go-CqHttp 的 API)
        /// </summary>
        public CqActionSender ActionSender => actionSender;

        /// <summary>
        /// 上报管线 (用来接收 Go-CqHttp 提供的上报数据)
        /// </summary>
        public CqPostPipeline PostPipeline => postPipeline;


        /// <summary>
        /// 当未捕捉的用户异常发生时
        /// </summary>
        public event UnhandledExceptionEventHandler? UnhandledException;


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
                apiWebSocket = new ClientWebSocket();

            // 如果使用事件接入点, 那么则初始化事件套接字
            if (options.UseEventEndPoint)
                eventWebSocket = new ClientWebSocket();

            // 如果任何一个没有被初始化, 则初始化根套接字
            if (eventWebSocket == null || apiWebSocket == null)
                webSocket = new ClientWebSocket();

            // 初始化 action 发送器 和 post 管道
            InitSession(out actionSender, out postPipeline, out postQueue);
        }

        /// <summary>
        /// 直接通过一个已经连接的远程 WebSocket 构建一个会话, 这个只会被反向 WebSocket 会话所调用
        /// </summary>
        /// <param name="remoteWebSocket"></param>
        /// <param name="baseUri"></param>
        /// <param name="accessToken"></param>
        /// <param name="bufferSize"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal CqWsSession(WebSocket remoteWebSocket, Uri baseUri, string? accessToken, int bufferSize)
        {
            webSocket = remoteWebSocket ?? throw new ArgumentNullException(nameof(remoteWebSocket));

            BaseUri = baseUri;
            AccessToken = accessToken;
            BufferSize = bufferSize;

            actionSender = new CqWsActionSender(this, remoteWebSocket);
            postPipeline = new CqPostPipeline();
            postQueue = new ConcurrentQueue<CqPostModel>();
        }

        /// <summary>
        /// 初始化会话所需的一些方法 (内部有对实例字段判空) (二次调用不会产生副作用)
        /// </summary>
        /// <param name="actionSender"></param>
        /// <param name="postPipeline"></param>
        /// <param name="postQueue"></param>
        /// <exception cref="InvalidOperationException">不可能发生的异常</exception>
        private void InitSession(out CqWsActionSender actionSender, out CqPostPipeline postPipeline, out ConcurrentQueue<CqPostModel> postQueue)
        {
            WebSocket webSocketForApi = apiWebSocket ?? webSocket ?? throw new InvalidOperationException("This would never happened");

            // 如果为空, 或者如果套接字变更了, 则重新初始化
            actionSender = this.actionSender == null || this.actionSender.Connection != webSocketForApi ?
                new CqWsActionSender(this, webSocketForApi) :
                this.actionSender;

            // 单例
            postPipeline = this.postPipeline == null ? 
                new CqPostPipeline() : 
                this.postPipeline;

            // 单例
            postQueue = this.postQueue == null ? 
                new ConcurrentQueue<CqPostModel>() :
                this.postQueue;

            // clear post queue
            while (!postQueue.IsEmpty)
                postQueue.TryDequeue(out _);
        }

        /// <summary>
        /// 处理 WebSocket 数据
        /// </summary>
        /// <param name="wsDataModel"></param>
        /// <returns></returns>
        private void ProcWsDataAsync(CqWsDataModel? wsDataModel)
        {
            // 如果是 post 上报
            if (wsDataModel is CqPostModel postModel)
            {
                postQueue.Enqueue(postModel);
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
                IsConnected &= webSocket.State == WebSocketState.Open;

                if (!IsConnected)
                    return;

                try
                {
                    // 重置内存流
                    ms.SetLength(0);
                    // 读取一个消息
                    var type = 
                        await webSocket.ReadMessageAsync(ms, buffer, default);

                    // 如果收到的是关闭消息, 则关闭会话并 break
                    if (type == WebSocketMessageType.Close)
                    {
                        await CloseAsync();
                        break;
                    }
                }
                catch (ObjectDisposedException)
                {
                    // 当 WebSocket 被 Dispose 的时候, 不扔异常, 但是终止循环 (因为 Dispose 是主动进行的
                    break;
                }
                catch (WebSocketException)
                {
                    // 当 WebSocket 坏了的时候, 也不扔异常, 但是终止循环
                    await StopAsync();
                    break;
                }
                catch
                {
                    // 忽略其他异常
                    continue;
                }

                // 在发布模式下套一层 try 防止消息循环中断
#if RELEASE
                try  // 直接捕捉 JSON 反序列化异常
                {
#endif
#if DEBUG
                // 反序列化为 WebSocket 数据 (自己抽的类
                string json = GlobalConfig.TextEncoding.GetString(ms.ToArray());
                Debug.WriteLine("--------------------");
                Debug.WriteLine(json);
                Debug.WriteLine("--------------------");
#endif

                    ms.Seek(0, SeekOrigin.Begin);
                    CqWsDataModel? wsDataModel = JsonSerializer.Deserialize<CqWsDataModel>(ms, JsonHelper.Options);

                    // 处理 WebSocket 数据
                    ProcWsDataAsync(wsDataModel);

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
                catch (Exception ex)
                {
                    // 其他异常也应该是用户抛出来的, 忽略掉, 不能将 Session 终止, 但是使用事件通知一下
                    UnhandledException?.Invoke(this, new UnhandledExceptionEventArgs(ex, false));
                }
#endif
            }
        }

        private async Task PostProcLoop()
        {
            while (!disposed)
            {
                if (!IsConnected)
                    return;

                if (postQueue.TryDequeue(out var postModel))
                {
                    CqPostContext? postContext = CqPostContext.FromModel(postModel);
                    postContext?.SetSession(this);

                    // 如果 post 上下文不为空, 则使用 PostPipeline 处理该事件
                    if (postContext != null)
                    {
                        try
                        {
                            await postPipeline.ExecuteAsync(postContext);

                            // WebSocket 需要模拟 QuickAction
                            await actionSender.HandleQuickAction(postContext, postModel);
                        }
                        catch (Exception ex)
                        {
                            UnhandledException?.Invoke(this, new UnhandledExceptionEventArgs(ex, false));
                        }
                    }
                }
                else
                {
                    await Task.Delay(1);
                }
            }
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        private async Task ConnectAsync()
        {
            string accessTokenHeaderValue = $"Bearer {AccessToken}";

            // 如果当前会话不是一个用户创建的, 则抛异常
            if (webSocket is not ClientWebSocket &&
                apiWebSocket is not ClientWebSocket &&
                eventWebSocket is not ClientWebSocket)
                throw new InvalidOperationException($"You can't connect a closed incomming session. Only {nameof(CqWsSession)} created by user can use '{nameof(ConnectAsync)}'");

            // 如果 api 套接字不为空, 则连接 api 套接字
            if (apiWebSocket is ClientWebSocket apiWebSocketClient)
            {
                // 如果已经连接了, 就不需要连接了
                if (apiWebSocket.State == WebSocketState.Open)
                    return;
                // 如果不是默认状态, 不能连接, 需要重建
                if (apiWebSocketClient.State != WebSocketState.None)
                    apiWebSocket = apiWebSocketClient = new ClientWebSocket();

                if (AccessToken is not null)
                    apiWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await apiWebSocketClient.ConnectAsync(new Uri(BaseUri, "api"), default);
            }

            // 如果事件套接字不为空, 则连接事件套接字
            if (eventWebSocket is ClientWebSocket eventWebSocketClient)
            {
                // 如果已经连接了, 就不需要连接了
                if (eventWebSocket.State == WebSocketState.Open)
                    return;
                // 如果不是默认状态, 不能连接, 需要重建
                if (eventWebSocket.State != WebSocketState.None)
                    eventWebSocket = eventWebSocketClient = new ClientWebSocket();

                if (AccessToken is not null)
                    eventWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await eventWebSocketClient.ConnectAsync(new Uri(BaseUri, "event"), default);
            }

            // 如果任意一个为空且基础套接字部不为空, 则连接基础套接字
            if ((apiWebSocket == null || eventWebSocket == null) && webSocket is ClientWebSocket webSocketClient)
            {
                // 如果已经连接了, 就不需要连接了
                if (webSocket.State == WebSocketState.Open)
                    return;
                // 如果不是默认状态, 不能连接, 需要重建
                if (webSocket.State != WebSocketState.None)
                    webSocket = webSocketClient = new ClientWebSocket();

                if (AccessToken is not null)
                    webSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await webSocketClient.ConnectAsync(BaseUri, default);
            }

            // 进行字段的初始化 (重复调用不会有副作用, 如果是对一个已经关闭的 Session 重新调用, 则会生成新实例)
            InitSession(out actionSender, out postPipeline, out postQueue);

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
            if (apiWebSocket != null)
            {
                if (apiWebSocket.State == WebSocketState.Open)
                    await apiWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
                apiWebSocket.Dispose();
            }

            if (eventWebSocket != null)
            {
                if (eventWebSocket.State == WebSocketState.Open)
                    await eventWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
                eventWebSocket.Dispose();
            }

            if (webSocket != null)
            {
                if (webSocket.State == WebSocketState.Open)
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
                webSocket.Dispose();
            }

            // 关于套接字的主循环, 会自动关闭

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
            mainLoopTask = WebSocketLoop(webSocket ?? eventWebSocket ?? throw new InvalidOperationException("This would never happened"));

            // 当使用单独的 API 套接字的时候, 我们需要监听 API 套接字
            if (apiWebSocket != null)
                standaloneActionLoopTask = WebSocketLoop(apiWebSocket);

            // 单独线程处理上报
            mainPostLoopTask = PostProcLoop();
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
            // 当 mainLoopTask 被赋值的时候, mainPostLoopTask 也会被赋值, 所以第二个条件基本不会执行
            if (mainLoopTask == null || mainPostLoopTask == null)
                throw new InvalidOperationException("Session is not started yet");

            await Task.WhenAll(mainLoopTask, mainPostLoopTask);
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

        /// <summary>
        /// 释放掉资源 (关闭当前 WS 连接)
        /// </summary>
        public void Dispose()
        {
            if (disposed)
                return;

            apiWebSocket?.Dispose();
            eventWebSocket?.Dispose();
            webSocket?.Dispose();

            GC.SuppressFinalize(this);
            disposed = true;
        }
    }
}