using System.Linq;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 发送私聊转发消息
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="userId"></param>
/// <param name="message"></param>
public class CqSendPrivateForwardMessageAction(long userId, CqForwardMessage message) : CqAction
{

    /// <summary>
    /// 
    /// </summary>
    public override CqActionType ActionType => CqActionType.SendPrivateForwardMessage;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 转发消息
    /// </summary>
    public CqForwardMessage ForwardMessage { get; set; } = message;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSendPrivateForwardMsgActionParamsModel(UserId, ForwardMessage.Select(CqMsg.ToModel).ToArray());
    }
}