using NullLib.GoCqHttpSdk.Event;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public class CqWsSession
    {
        private Uri wsUri;
        private string? accessToken;

        private ClientWebSocket? webSocketClient;

        private bool isConnected;
        public bool IsConnected => isConnected;

        public static int BufferSize { get; set; } = 1024;
        public static int WebSocketKeepAliveInterval { get; } = 30;

        public CqWsSession(Uri wsUri)
        {
            this.wsUri = wsUri;
        }

        public CqWsSession(Uri wsUri, string accessToken)
        {
            this.wsUri = wsUri;
            this.accessToken = accessToken;
        }

        private async Task WebSocketLoopAsync()
        {
            if (webSocketClient == null)
                return;

            byte[] buffer = new byte[BufferSize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                ms.SetLength(0);
                WebSocketReceiveResult webSocketReceiveResult;

                do
                {
                    webSocketReceiveResult = await webSocketClient.ReceiveAsync(buffer, default);
                    ms.Write(buffer, 0, webSocketReceiveResult.Count);
                }
                while (!webSocketReceiveResult.EndOfMessage);

                try
                {
                    ms.Seek(0, SeekOrigin.Begin);
#if DEBUG
                    var qwq = Encoding.UTF8.GetString(ms.ToArray());
#endif
                    CqEventModel? eventModel = await JsonSerializer.DeserializeAsync<CqEventModel>(ms, JsonHelper.GetOptions());
                    CqEventArgs? eventArgs = CqEventArgs.FromModel(eventModel);
#if DEBUG
                    Debug.Write(string.Empty);
#endif

                    
                }
                catch { }
            }
        }

        private void ProcEvent(CqEventArgs? eventArgs)
        {
            
        }

        /// <summary>
        /// connect websocket.
        /// only call when websocket is enabled
        /// </summary>
        /// <returns></returns>
        private async Task ConnectWebSocketAsync()
        {
            webSocketClient = new ClientWebSocket();

            if (accessToken != null)
                webSocketClient.Options.SetRequestHeader("Authorization", "Bearer " + accessToken);   // 鉴权

            await webSocketClient.ConnectAsync(wsUri, new CancellationToken());
            _ = WebSocketLoopAsync();

            isConnected = true;
        }

        public async Task ConnectAsync()
        {
            if (wsUri != null)
                await ConnectWebSocketAsync();
        }


    }

    public struct CqWsSessionOption
    {
        public Uri WebSocketUri { get; set; }

        public string? AccessToken { get; set; }
    }
}
