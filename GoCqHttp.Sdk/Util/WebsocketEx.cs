using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Utils
{
    internal static class WebsocketEx
    {
        //static Dictionary<WebSocket, AutoResetEvent> WsReadLockers = new Dictionary<WebSocket, AutoResetEvent>();
        public static async Task<WebSocketMessageType> ReadMessageAsync(this WebSocket ws, Stream stream, byte[] buffer, CancellationToken cancellationToken)
        {
            // 声明一个接收结果
            WebSocketReceiveResult webSocketReceiveResult;

            //// 声明一个等待句柄
            //AutoResetEvent? locker;

            //// 获取或创建等待句柄
            //if (!WsReadLockers.TryGetValue(ws, out locker))
            //{
            //    // 初始状态为 true (有信号)
            //    WsReadLockers[ws] = locker = new AutoResetEvent(true);
            //}

            //// 等待一个信号 (此时其他线程不可访问
            //locker.WaitOne();

            // 循环读取, 直到取完整个消息
            do
            {
                ArraySegment<byte> bufferSegment = new ArraySegment<byte>(buffer);
                webSocketReceiveResult = await ws.ReceiveAsync(bufferSegment, cancellationToken);
                stream.Write(buffer, 0, webSocketReceiveResult.Count);
            }
            while (!webSocketReceiveResult.EndOfMessage);

            //// 设定一个信号 (允许其他线程访问
            //locker.Set();

            return webSocketReceiveResult.MessageType;
        }
    }
}