using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 精华消息
/// </summary>
public record class CqEssenceMessage
{
    internal CqEssenceMessage(CqEssenceMessageModel model)
    {
        SenderId = model.sender_id;
        SenderNickname = model.sender_nick;

        OperatorId = model.operator_id;
        OperatorNickname = model.operator_nick;

        MessageId = model.message_id;

        SendTime = DateTimeOffset.FromUnixTimeSeconds(model.sender_time).DateTime;
        OperationTime = DateTimeOffset.FromUnixTimeSeconds(model.operator_time).DateTime;
    }


    /// <summary>
    /// 构建精华消息
    /// </summary>
    /// <param name="senderId">发送者 QQ</param>
    /// <param name="senderNickname">发送者昵称</param>
    /// <param name="operatorId">操作者 QQ</param>
    /// <param name="operatorNickname">操作者昵称</param>
    /// <param name="messageId">消息 ID</param>
    /// <param name="sendTime">发送时间</param>
    /// <param name="operationTime">操作时间</param>
    [JsonConstructor]
    public CqEssenceMessage(long senderId, string senderNickname, long operatorId, string operatorNickname, long messageId, DateTime sendTime, DateTime operationTime)
    {
        SenderId = senderId;
        SenderNickname = senderNickname;
        OperatorId = operatorId;
        OperatorNickname = operatorNickname;
        MessageId = messageId;
        SendTime = sendTime;
        OperationTime = operationTime;
    }


    /// <summary>
    /// 发送者 QQ
    /// </summary>
    public long SenderId { get; }

    /// <summary>
    /// 发送者昵称
    /// </summary>
    public string SenderNickname { get; }

    /// <summary>
    /// 操作者 QQ
    /// </summary>
    public long OperatorId { get; }

    /// <summary>
    /// 操作者昵称
    /// </summary>
    public string OperatorNickname { get; }

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; }

    /// <summary>
    /// 发送时间
    /// </summary>
    public DateTime SendTime { get; }

    /// <summary>
    /// 操作时间
    /// </summary>
    public DateTime OperationTime { get; set; }
}
