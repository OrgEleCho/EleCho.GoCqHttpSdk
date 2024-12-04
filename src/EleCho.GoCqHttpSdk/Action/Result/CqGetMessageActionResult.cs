using EleCho.GoCqHttpSdk.Message;
using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System.Linq;
using EleCho.GoCqHttpSdk.DataStructure;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 获取消息操作结果
/// </summary>
public record class CqGetMessageActionResult : CqActionResult
{
    /// <summary>
    /// 是群消息
    /// </summary>
    public bool IsGroupMessage { get; private set; }

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; private set; }

    /// <summary>
    /// 真实 ID
    /// </summary>
    public int RealId { get; private set; }

    /// <summary>
    /// 发送者
    /// </summary>
    public CqMessageSender Sender { get; private set; } = new CqMessageSender();

    /// <summary>
    /// 时间
    /// </summary>
    public DateTime Time { get; private set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    public CqMessage Message { get; private set; } = [];

    /// <summary>
    /// 消息原始内容 (CQ 码)
    /// </summary>
    public string RawMessage { get; private set; } = string.Empty;

    internal CqGetMessageActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is CqGetMessageActionResultDataModel dataModel)
        {
            IsGroupMessage = dataModel.group;
            MessageId = dataModel.message_id;
            RealId = dataModel.real_id;
            Sender = new CqMessageSender(dataModel.sender);
            Time = DateTimeOffset.FromUnixTimeSeconds(dataModel.time).DateTime;
            Message = new CqMessage(dataModel.message.Select(CqMsg.FromModel));
            RawMessage = dataModel.raw_message;
        }
    }
}