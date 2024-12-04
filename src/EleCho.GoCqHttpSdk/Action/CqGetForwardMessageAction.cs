using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取转发消息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="messageId">消息 ID</param>
public class CqGetForwardMessageAction(long messageId) : CqAction
{
    /// <summary>
    /// 操作类型: 获取转发消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetForwardMessage;

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; set; } = messageId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetForwardMessageActionParamsModel(MessageId);
    }
}