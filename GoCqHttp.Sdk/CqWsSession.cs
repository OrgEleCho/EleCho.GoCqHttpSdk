using NullLib.GoCqHttpSdk.Action.Invoker;
using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Model;
using NullLib.GoCqHttpSdk.Post;
using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    /// <summary>
    /// 正向 WebSocket Session
    /// 可处理上报, 以及发送 Action
    /// </summary>
    public class CqWsSession : ICqPostSession, ICqActionSession
    {
        // 基础接入点地址和访问令牌
        private readonly Uri baseUri;

        // 访问令牌
        private readonly string? accessToken;

        public Uri BaseUri => baseUri;
        public string? AccessToken => accessToken;

        // 三个接入点的套接字
        private ClientWebSocket? webSocketClient;

        private ClientWebSocket? apiWebSocketClient;
        private ClientWebSocket? eventWebSocketClient;


        private bool isConnected;
        public bool IsConnected => isConnected;

        // websocket 缓冲区大小
        public static int BufferSize { get; set; } = 1024;

        // 用来发送 API 请求
        private readonly CqWsActionSender actionSender;

        // 用来处理 post 上报事件
        private readonly CqPostPipeline postPipeline;

        public CqActionSender ActionSender => actionSender;
        public CqPostPipeline PostPipeline => postPipeline;

        public CqWsSession(CqWsSessionOptions options)
        {
            // 设定基础地址和访问令牌
            this.baseUri = options.BaseUri;
            this.accessToken = options.AccessToken;

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
            actionSender = new CqWsActionSender((apiWebSocketClient ?? webSocketClient)!, options.UseApiEndPoint);
            postPipeline = new CqPostPipeline();

            // 开启套接字循环
            _ = WebSocketLoopAsync();
        }

        /// <summary>
        /// 处理 WebSocket 数据
        /// </summary>
        /// <param name="wsDataModel"></param>
        /// <returns></returns>
        private Task ProcWsData(CqWsDataModel? wsDataModel)
        {
            return Task.Run(async () =>
            {
                // 如果是 post 上报
                if (wsDataModel is CqPostModel postModel)
                {
                    CqPostContext? postContext = CqPostContext.FromModel(postModel);

                    // 如果 post 上下文不为空, 则使用 PostPipeline 处理该事件
                    if (postContext != null)
                        await postPipeline.ExecuteAsync(postContext);
                }
                // 否则如果是 action 请求响应
                else if (wsDataModel is CqActionResultRaw actionResultRaw)
                {
                    // 将请求放入 ActionSender 进行处理
                    actionSender.PutResult(actionResultRaw);
                }
            });
        }

        /// <summary>
        /// WebSocket 循环 (不要等待这个方法)
        /// </summary>
        /// <returns></returns>
        private async Task WebSocketLoopAsync()
        {
            // 初始化 WebSocket (使用 event socket 或者根 socket
            WebSocket? webSocket2Listen = eventWebSocketClient ?? webSocketClient;
            if (webSocket2Listen == null)
                return;

            // 初始化缓冲区
            byte[] buffer = new byte[BufferSize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                if (webSocket2Listen.State != WebSocketState.Open)
                {
                    await Task.Delay(100);
                    continue;
                }

                // 重置内存流
                ms.SetLength(0);

                // 读取一个消息
                await webSocket2Listen.ReadMessageAsync(ms, buffer, default);

                // 在发布模式下套一层 try 防止消息循环中断
#if RELEASE
                try
                {
#endif
                // 反序列化为 WebSocket 数据 (自己抽的类
                string json = GlobalConfig.TextEncoding.GetString(ms.ToArray());
                CqWsDataModel? wsDataModel = JsonSerializer.Deserialize<CqWsDataModel>(json, JsonHelper.GetOptions());

                // 处理 WebSocket 数据
                _ = ProcWsData(wsDataModel);

#if RELEASE
                }
                catch { }
#endif
                isConnected = webSocket2Listen.State == WebSocketState.Open;
            }
        }

        /// <summary>
        /// connect websocket.
        /// only call when websocket is enabled
        /// </summary>
        /// <returns></returns>
        private async Task ConnectWebSocketAsync()
        {
            // 如果 api 套接字不为空, 则连接 api 套接字
            if (apiWebSocketClient != null)
            {
                if (apiWebSocketClient.State == WebSocketState.Open)
                    return;

                apiWebSocketClient.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");   // 鉴权
                string apiUriStr = Path.Combine(baseUri.ToString(), "api");
                await apiWebSocketClient.ConnectAsync(new Uri(apiUriStr), default);
            }

            // 如果事件套接字不为空, 则连接事件套接字
            if (eventWebSocketClient != null)
            {
                if (eventWebSocketClient.State == WebSocketState.Open)
                    return;

                eventWebSocketClient.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");   // 鉴权
                string eventUriStr = Path.Combine(baseUri.ToString(), "event");
                await eventWebSocketClient.ConnectAsync(new Uri(eventUriStr), default);
            }

            // 如果任意一个为空且基础套接字部不为空, 则连接基础套接字
            if ((apiWebSocketClient == null || eventWebSocketClient == null) && webSocketClient != null)
            {
                if (webSocketClient.State == WebSocketState.Open)
                    return;

                webSocketClient.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");   // 鉴权
                await webSocketClient.ConnectAsync(baseUri, default);
            }

            // 已连接设定为 true
            isConnected = true;
        }

        // 连接
        public async Task ConnectAsync()
        {
            if (baseUri != null)
                await ConnectWebSocketAsync();
        }

        public async Task CloseAsync()
        {
            if (apiWebSocketClient != null)
                await apiWebSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
            if (eventWebSocketClient != null)
                await eventWebSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);
            if (webSocketClient != null)
                await webSocketClient.CloseAsync(WebSocketCloseStatus.NormalClosure, null, default);

            isConnected = false;
        }
    }
}