using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class WsEx
    {
        static Dictionary<WebSocket, AutoResetEvent> WsReadLockers = new Dictionary<WebSocket, AutoResetEvent>();
        public static async Task<WebSocketMessageType> ReadMessageAsync(this WebSocket ws, Stream stream, byte[] buffer, CancellationToken cancellationToken)
        {
            WebSocketReceiveResult webSocketReceiveResult;

            AutoResetEvent? locker;
            
            if (!WsReadLockers.TryGetValue(ws, out locker))
            {
                WsReadLockers[ws] = locker = new AutoResetEvent(true);
            }

            locker.WaitOne();

            do
            {
                webSocketReceiveResult = await ws.ReceiveAsync(buffer, cancellationToken);
                stream.Write(buffer, 0, webSocketReceiveResult.Count);
            }
            while (!webSocketReceiveResult.EndOfMessage);

            locker.Set();

            return webSocketReceiveResult.MessageType;
        }
    }
}