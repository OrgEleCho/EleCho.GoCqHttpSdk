using NullLib.GoCqHttpSdk.Action.Model;
using NullLib.GoCqHttpSdk.Action.Result;
using NullLib.GoCqHttpSdk.Action.Result.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

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
            {
                wsMs = new MemoryStream();
                wsBuffer = new byte[GlobalConfig.WebSocketBufferSize];
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

        private MemoryStream? wsMs;
        private byte[]? wsBuffer;

        public override async Task<CqActionResult?> SendActionAsync(CqAction action)
        {
            // 生成唯一标识符
            string echo = Guid.NewGuid().ToString();

            // 获取数据
            CqActionModel actionModel = CqAction.ToModel(action);
            actionModel.echo = echo;

            // 序列化
            string json = JsonSerializer.Serialize(actionModel);
            byte[] buffer = GlobalConfig.TextEncoding.GetBytes(json);

            // 发送请求
            await Ws.SendAsync(buffer[0..buffer.Length], WebSocketMessageType.Text, true, default);

            CqActionResult? rst = null;

            // 如果允许直接读取响应
            if (ReadResult)
            {
                wsMs!.SetLength(0);

                Task responseReadTask = Ws.ReadMessage(wsMs!, wsBuffer!, default);

                // 等待任务结束或超时
                await Task.WhenAny(Task.Delay(WaitTimeout), responseReadTask);

                if (responseReadTask.IsCompleted)
                {
                    string rstjson = GlobalConfig.TextEncoding.GetString(wsMs!.ToArray());
#if DEBUG
                    Console.WriteLine(rstjson);
#endif

                    CqActionResultRaw? resultRaw = JsonSerializer.Deserialize<CqActionResultRaw>(rstjson, JsonHelper.GetOptions());
                    rst = CqActionResult.FromRaw(resultRaw, action.Type);
                }
            }
            else
            {
                // 创建等待
                AutoResetEvent handle = new AutoResetEvent(false);
                results[echo] = (handle, null);

                // 等待响应
                handle.WaitOne(WaitTimeout);
                rst = CqActionResult.FromRaw(results[echo].result, action.Type);

                // 删除存储
                results.Remove(echo);
            }

            return rst;
        }
    }
}