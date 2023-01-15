using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Model;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Action.Invoker
{
    public class CqWsActionSender : CqActionSender
    {
        // 响应存储
        private readonly Dictionary<string, (AutoResetEvent handle, CqActionResultRaw? result)> results;

        // 父 Session
        public CqWsSession? Session { get; }

        // 基础套接字
        public WebSocket Connection { get; }

        // 是否读取结果
        public bool ReadResult { get; }

        // 响应等待超时
        public TimeSpan WaitTimeout { get; set; } = GlobalConfig.WaitTimeout;

        public CqWsActionSender(CqWsSession? session, WebSocket connection, bool readResult)
        {
            Session = session;
            Connection = connection;
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
                if (Connection.State != WebSocketState.Open)
                {
                    await Task.Delay(100);
                    continue;
                }

#if RELEASE
                try
                {
#endif
                    wsMs.SetLength(0);
                    await Connection.ReadMessageAsync(wsMs, wsBuffer, default);
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
                    CqWsDataModel? resultRaw = JsonSerializer.Deserialize<CqWsDataModel>(rstjson, JsonHelper.Options);
                    if (resultRaw is CqActionResultRaw rstRaw)
                        PutResult(rstRaw);
                    else if (resultRaw is CqPostModel postModel)
                        Session?.ProcPostModelAsync(postModel);
                    
#if DEBUG
                    Console.WriteLine($"{JsonSerializer.Serialize(JsonDocument.Parse(rstjson), JsonHelper.Options)}");
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
            await Connection.SendAsync(bufferSegment, WebSocketMessageType.Text, true, default);

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