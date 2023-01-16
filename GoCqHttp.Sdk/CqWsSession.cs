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
        public Uri BaseUri { get; }
        public string? AccessToken { get; }

        // 主循环线程
        private Thread mainLoopThread;

        // 三个接入点的套接字
        private ClientWebSocket? webSocketClient;

        private ClientWebSocket? apiWebSocketClient;
        private ClientWebSocket? eventWebSocketClient;

        public bool IsConnected { get; private set; }

        // websocket 缓冲区大小
        public int BufferSize { get; set; } = 1024;

        // 用来发送 API 请求
        private readonly CqWsActionSender actionSender;

        // 用来处理 post 上报事件
        private readonly CqPostPipeline postPipeline;

        public CqActionSender ActionSender => actionSender;
        public CqPostPipeline PostPipeline => postPipeline;
        

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
            actionSender = new CqWsActionSender(this, (apiWebSocketClient ?? webSocketClient)!, options.UseApiEndPoint);
            postPipeline = new CqPostPipeline();

            // 开启套接字循环
            mainLoopThread = new Thread(WebSocketLoop);
            mainLoopThread.Start();
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
                actionSender.PutResult(actionResultRaw);
            }
        }

        /// <summary>
        /// WebSocket 循环
        /// </summary>
        /// <returns></returns>
        private async void WebSocketLoop()
        {
            // 初始化 WebSocket (使用 event socket 或者根 socket
            WebSocket? webSocket2Listen = eventWebSocketClient ?? webSocketClient;
            if (webSocket2Listen == null)
                return;

            // 初始化缓冲区
            byte[] buffer = new byte[BufferSize];
            MemoryStream ms = new MemoryStream();
            while (!disposed)
            {
                IsConnected = webSocket2Listen.State == WebSocketState.Open;
                
                if (!IsConnected)
                {
                    await Task.Delay(100);
                    continue;
                }

                try
                {
                    // 重置内存流
                    ms.SetLength(0);
                    // 读取一个消息
                    await webSocket2Listen.ReadMessageAsync(ms, buffer, default);
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

        // 连接
        public async Task ConnectAsync()
        {
            string accessTokenHeaderValue = $"Bearer {AccessToken}";

            // 如果 api 套接字不为空, 则连接 api 套接字
            if (apiWebSocketClient != null)
            {
                if (apiWebSocketClient.State == WebSocketState.Open)
                    return;

                apiWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                string apiUriStr = Path.Combine(BaseUri.ToString(), "api");
                await apiWebSocketClient.ConnectAsync(new Uri(apiUriStr), default);
            }

            // 如果事件套接字不为空, 则连接事件套接字
            if (eventWebSocketClient != null)
            {
                if (eventWebSocketClient.State == WebSocketState.Open)
                    return;

                eventWebSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                string eventUriStr = Path.Combine(BaseUri.ToString(), "event");
                await eventWebSocketClient.ConnectAsync(new Uri(eventUriStr), default);
            }

            // 如果任意一个为空且基础套接字部不为空, 则连接基础套接字
            if ((apiWebSocketClient == null || eventWebSocketClient == null) && webSocketClient != null)
            {
                if (webSocketClient.State == WebSocketState.Open)
                    return;

                webSocketClient.Options.SetRequestHeader("Authorization", accessTokenHeaderValue);   // 鉴权
                await webSocketClient.ConnectAsync(BaseUri, default);
            }

            // 已连接设定为 true
            IsConnected = true;
        }

        public async Task CloseAsync()
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