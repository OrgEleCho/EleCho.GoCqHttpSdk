using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action.Model;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Action.Sender;

/// <summary>
/// WebSocket 的操作发送器
/// </summary>
/// <remarks>
/// 构造新的操作发送器
/// </remarks>
/// <param name="session"></param>
/// <param name="connection"></param>
public class CqWsActionSender(CqWsSession? session, WebSocket connection) : CqActionSender
{
    // 响应存储
    private readonly Dictionary<string, TaskCompletionSource<CqActionResultRaw?>> results = [];

    /// <summary>
    /// 父 Session
    /// </summary>
    public CqWsSession? Session { get; } = session;

    /// <summary>
    /// 基础网络套接字
    /// </summary>
    public WebSocket Connection { get; } = connection;

    /// <summary>
    /// 响应超时
    /// </summary>
    public TimeSpan WaitTimeout { get; set; } = GlobalConfig.WaitTimeout;

    /// <summary>
    /// 将操作响应结果放入到发送器中, 以使发送器响应对应的操作 (这个应该由 WebSocket 会话调用)
    /// </summary>
    /// <param name="result"></param>
    internal void PutActionResult(CqActionResultRaw result)
    {
        if (result.echo == null)
            return;

        if (results.TryGetValue(result.echo, out TaskCompletionSource<CqActionResultRaw?>? tp))
            tp.SetResult(result);
    }

    /// <summary>
    /// 异步执行操作
    /// </summary>
    /// <param name="action">要执行的操作</param>
    /// <returns>可等待的操作结果</returns>
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
        TaskCompletionSource<CqActionResultRaw?> tp = new TaskCompletionSource<CqActionResultRaw?>();
        results[echo] = tp;

        // 等待响应
        CqActionResultRaw? resultRaw = await tp.Task;
        rst = CqActionResult.FromRaw(resultRaw, actionModel.action);

        // 删除存储
        results.Remove(echo);

        return rst;
    }

    internal override async Task<bool> HandleQuickAction(CqPostContext context, CqPostModel postModel)
    {
        if (context.QuickOperationModel == null)
            return true;

        object bodyModel = new
        {
            context = postModel,
            operation = context.QuickOperationModel
        };

        // 获取数据
        CqActionModel actionModel = new CqActionModel(Consts.ActionType.HandleQuickOperation, bodyModel);

        // 序列化
        string json = JsonSerializer.Serialize(actionModel, JsonHelper.Options);
        byte[] buffer = GlobalConfig.TextEncoding.GetBytes(json);

        // 发送请求
        ArraySegment<byte> bufferSegment = new ArraySegment<byte>(buffer);
        await Connection.SendAsync(bufferSegment, WebSocketMessageType.Text, true, default);

        return true;
    }
}