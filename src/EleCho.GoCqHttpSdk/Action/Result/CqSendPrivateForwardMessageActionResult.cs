using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送私聊转发消息操作结果
/// </summary>
public record class CqSendPrivateForwardMessageActionResult : CqActionResult
{
    internal CqSendPrivateForwardMessageActionResult() { }

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; private set; }

    /// <summary>
    /// 转发 ID
    /// </summary>
    public string ForwardId { get; private set; } = string.Empty;

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqSendPrivateForwardMessageActionResultDataModel m)
            throw new Exception();

        MessageId = m.message_id;
        ForwardId = m.forward_id;
    }
}