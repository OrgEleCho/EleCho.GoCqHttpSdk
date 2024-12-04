using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 标记消息已读操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="messageId"></param>
public class CqMarkMessageAsReadAction(long messageId) : CqAction
{

    /// <summary>
    /// 操作类型: 标记消息已读
    /// </summary>
    public override CqActionType ActionType => CqActionType.MarkMessageAsRead;

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; set; } = messageId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqMarkMessageAsReadActionParamsModel(MessageId);
    }
}
