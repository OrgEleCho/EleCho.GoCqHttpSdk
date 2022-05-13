using NullLib.GoCqHttpSdk.Action.Model;
using NullLib.GoCqHttpSdk.Action.Result;
using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace NullLib.GoCqHttpSdk.Action.Invoker
{
    public class CqWsActionSender : CqActionSender
    {
        // 响应存储
        private Dictionary<string, (AutoResetEvent handle, CqActionResultRaw? result)> results;

        // 基础套接字
        public WebSocket Ws { get; }

        public bool ReadResult { get; }

        // 响应等待超时
        public TimeSpan WaitTimeout { get; set; } = GlobalConfig.WaitTimeout;

        public CqWsActionSender(WebSocket ws, bool readResult)
        {
            Ws = ws;
            ReadResult = readResult;
            results = new Dictionary<string, (AutoResetEvent, CqActionResultRaw?)>();

            if (readResult)
                _ = WebSocketLoopAsync();
        }

        private async Task WebSocketLoopAsync()
        {
            MemoryStream wsMs = new MemoryStream();
            byte[] wsBuffer = new byte[GlobalConfig.WebSocketBufferSize];

            while (true)
            {
                if (Ws.State != WebSocketState.Open)
                {
                    await Task.Delay(100);
                    continue;
                }
                
                wsMs.SetLength(0);
                await Ws.ReadMessageAsync(wsMs, wsBuffer, default);

                string rstjson = GlobalConfig.TextEncoding.GetString(wsMs!.ToArray()); // 文本
                CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, JsonHelper.GetOptions());
                if (resultRaw != null)
                    PutResult(resultRaw);
            }
        }

        // 放入结果
        internal void PutResult(CqActionResultRaw result)
        {
            if (result.echo == null)
                return;

            if (results.TryGetValue(result.echo, out (AutoResetEvent handle, CqActionResultRaw? result) tp))
            {
                results[result.echo] = (tp.handle, result);
                tp.handle.Set();
            }
        }

        public override async Task<CqActionResult?> SendActionAsync(CqAction action)
        {
            // 生成唯一标识符
            string echo = Guid.NewGuid().ToString();

            // 获取数据
            CqActionModel actionModel = CqAction.ToModel(action);
            actionModel.echo = echo;

            // 序列化
            string json = JsonSerializer.Serialize(actionModel, JsonHelper.GetOptions());
            byte[] buffer = GlobalConfig.TextEncoding.GetBytes(json);

            // 发送请求
            await Ws.SendAsync(buffer[0..buffer.Length], WebSocketMessageType.Text, true, default);

            CqActionResult? rst;
            
            // 创建等待
            AutoResetEvent handle = new AutoResetEvent(false);
            results[echo] = (handle, null);

            // 等待响应
            handle.WaitOne(WaitTimeout);
            rst = CqActionResult.FromRaw(results[echo].result, action.Type);

            // 删除存储
            results.Remove(echo);

            return rst;
        }
    }
}