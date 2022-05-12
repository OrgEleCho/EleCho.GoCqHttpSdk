using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class WsEx
    {
        public static async Task<WebSocketMessageType> ReadMessage(this WebSocket ws, Stream stream, byte[] buffer, CancellationToken cancellationToken)
        {
            WebSocketReceiveResult webSocketReceiveResult;
            
            do
            {
                webSocketReceiveResult = await ws.ReceiveAsync(buffer, cancellationToken);
                stream.Write(buffer, 0, webSocketReceiveResult.Count);
            }
            while (!webSocketReceiveResult.EndOfMessage);

            return webSocketReceiveResult.MessageType;
        }
    }
}
