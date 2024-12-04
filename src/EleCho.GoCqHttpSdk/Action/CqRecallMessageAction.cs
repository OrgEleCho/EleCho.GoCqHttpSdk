using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 撤回消息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="messageId">要撤回的消息 ID</param>
public class CqRecallMessageAction(long messageId) : CqAction
{
    /// <summary>
    /// 操作类型: 撤回消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.RecallMessage;

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; set; } = messageId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqRecallMessageActionParamsModel(MessageId);
    }
}