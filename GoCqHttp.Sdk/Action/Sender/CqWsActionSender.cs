using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Invoker
{
    public class CqWsActionSender : CqActionSender
    {
        // 响应存储
        private readonly Dictionary<string, (AutoResetEvent handle, CqActionResultRaw? result)> results;

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

#if RELEASE
                try
                {
#endif
                    wsMs.SetLength(0);
                    await Ws.ReadMessageAsync(wsMs, wsBuffer, default);
#if RELEASE
                }
                catch
                {
                    continue;
                }
#endif

                try
                {
                    string rstjson = GlobalConfig.TextEncoding.GetString(wsMs.ToArray()); // 文本
                    CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, JsonHelper.Options);
                    if (resultRaw != null)
                        PutResult(resultRaw);
                    
#if DEBUG
                    Debug.WriteLine($"{JsonSerializer.Serialize(JsonDocument.Parse(rstjson), JsonHelper.Options)}");
#endif
                }
                catch (System.Text.DecoderFallbackException)
                {
                    // ignore text decode error
                }
                catch (JsonException)
                {
                    // ignore json error
                }
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

        public override async Task<CqActionResult?> InvokeActionAsync(CqAction action)
        {
            // 生成唯一标识符
            string echo = Guid.NewGuid().ToString();

            // 获取数据
            CqActionModel actionModel = CqAction.ToModel(action);
            actionModel.echo = echo;

            // 序列化
            string json = JsonSerializer.Serialize(actionModel, JsonHelper.Options);
            byte[] buffer = GlobalConfig.TextEncoding.GetBytes(json);

            // 发送请求
            ArraySegment<byte> bufferSegment = new ArraySegment<byte>(buffer);
            await Ws.SendAsync(bufferSegment, WebSocketMessageType.Text, true, default);

            CqActionResult? rst;

            // 创建等待
            AutoResetEvent handle = new AutoResetEvent(false);
            results[echo] = (handle, null);

            // 等待响应
            handle.WaitOne(WaitTimeout);
            rst = CqActionResult.FromRaw(results[echo].result, actionModel.action);

            // 删除存储
            results.Remove(echo);

            return rst;
        }
    }
}