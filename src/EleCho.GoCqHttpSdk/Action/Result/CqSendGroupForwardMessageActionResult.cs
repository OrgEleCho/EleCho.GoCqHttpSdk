using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送群转发消息操作结果
/// </summary>
public record class CqSendGroupForwardMessageActionResult : CqActionResult
{
    internal CqSendGroupForwardMessageActionResult() { }

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
        if (model is not CqSendGroupForwardMessageActionResultDataModel m)
            throw new Exception();

        MessageId = m.message_id;
        ForwardId = m.forward_id;
    }
}