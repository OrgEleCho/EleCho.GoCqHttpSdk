using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Message;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送消息操作 (群消息或私聊)
/// </summary>
public class CqSendMessageAction : CqAction
{
    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="userId">用户 QQ (如果你要发送私聊消息, 请填写这个参数)</param>
    /// <param name="groupId">群号 (如果你要发送群消息, 请填写这个参数)</param>
    /// <param name="message">消息</param>
    public CqSendMessageAction(long? userId, long? groupId, CqMessage message)
    {
        if (userId != null)
            MessageType = CqMessageType.Private;
        else
            MessageType = CqMessageType.Group;

        UserId = userId;
        GroupId = groupId;
        Message = message;
    }

    /// <summary>
    /// 全参数实例化对象
    /// </summary>
    /// <param name="messageType">消息类型</param>
    /// <param name="userId">用户 QQ</param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    public CqSendMessageAction(CqMessageType messageType, long? userId, long? groupId, CqMessage message)
    {
        MessageType = messageType;
        UserId = userId;
        GroupId = groupId;
        Message = message;
    }

    /// <summary>
    /// 操作类型: 发送消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.SendMessage;

    /// <summary>
    /// 消息类型
    /// </summary>
    public CqMessageType MessageType { get; set; } = CqMessageType.Unknown;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    public long? GroupId { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    public CqMessage Message { get; set; }

    /// <summary>
    /// 因为内部传输不使用 CQ 码, 所以该字段不可用
    /// </summary>
    [Obsolete("该字段不可用")]
    public bool AutoEscape { get; set; }

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSendMessageActionParamsModel(CqEnum.GetString(MessageType), UserId, GroupId, Message.Select(CqMsg.ToModel).ToArray());
    }
}