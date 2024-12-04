using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Message;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送群聊消息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="message">消息</param>
public class CqSendGroupMessageAction(long groupId, CqMessage message) : CqAction
{
    /// <summary>
    /// 操作类型: 发送群消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.SendGroupMessage;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 消息
    /// </summary>
    public CqMessage Message { get; set; } = message;


    /// <summary>
    /// 因为内部不使用 CQ 码, 所以该属性无用
    /// </summary>
    [Obsolete("该属性无用")]
    public bool AutoEscape { get; set; }

    internal override CqActionParamsModel GetParamsModel()
#pragma warning disable CS0618 // Type or member is obsolete
        => new CqSendGroupMessageActionParamsModel(GroupId, Message.Select(CqMsg.ToModel).ToArray(), AutoEscape);
#pragma warning restore CS0618 // Type or member is obsolete
}