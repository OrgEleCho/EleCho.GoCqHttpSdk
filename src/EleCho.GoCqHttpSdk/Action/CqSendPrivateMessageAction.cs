using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送私聊消息操作
/// </summary>
public class CqSendPrivateMessageAction : CqAction
{
    /// <summary>
    /// 操作类型: 发送私聊消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.SendPrivateMessage;


    /// <summary>
    /// 实例化对象 (通过群发起临时会话)
    /// </summary>
    /// <param name="userId">用户 QQ</param>
    /// <param name="groupId">群号</param>
    /// <param name="message">消息</param>
    public CqSendPrivateMessageAction(long userId, long groupId, CqMessage message)
    {
        UserId = userId;
        GroupId = groupId;
        Message = message;
    }

    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="userId">用户 QQ</param>
    /// <param name="message">消息内容</param>
    public CqSendPrivateMessageAction(long userId, CqMessage message)
    {
        UserId = userId;
        Message = message;
    }

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    public long? GroupId { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    public CqMessage Message { get; set; }

    /// <summary>
    /// 自动转义 (因为内部没有使用 CQ 码作为消息, 所以该属性无用)
    /// </summary>
    [Obsolete("该属性无用")]
    public bool AutoEscape { get; set; }

    internal override CqActionParamsModel GetParamsModel() =>
#pragma warning disable CS0618 // Type or member is obsolete
        new CqSendPrivateMessageActionParamsModel(UserId, GroupId, Message.Select(CqMsg.ToModel).ToArray(), AutoEscape);
#pragma warning restore CS0618 // Type or member is obsolete

}