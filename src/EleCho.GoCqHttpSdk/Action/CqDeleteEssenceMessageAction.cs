using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 删除精华消息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="messageId">要删除的精华消息 ID</param>
public class CqDeleteEssenceMessageAction(long messageId) : CqAction
{
    /// <summary>
    /// 操作类型: 删除精华消息
    /// </summary>
    public override CqActionType ActionType => CqActionType.DeleteEssenceMessage;

    /// <summary>
    /// 消息 ID
    /// </summary>
    public long MessageId { get; set; } = messageId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDeleteEssenceMessageActionParamsModel(MessageId);
    }
}
