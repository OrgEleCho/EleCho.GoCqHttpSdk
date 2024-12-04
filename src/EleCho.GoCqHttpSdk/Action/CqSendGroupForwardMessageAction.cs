using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送群转发消息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId"></param>
/// <param name="messages"></param>
public class CqSendGroupForwardMessageAction(long groupId, CqForwardMessage messages) : CqAction
{

    /// <summary>
    /// 操作类型: 发送群转发消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.SendGroupForwardMessage;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 转发消息
    /// </summary>
    public CqForwardMessage ForwardMessage { get; set; } = messages;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSendGroupForwardMessageActionParamsModel(GroupId, ForwardMessage.Select(CqMsg.ToModel).ToArray());
    }
}