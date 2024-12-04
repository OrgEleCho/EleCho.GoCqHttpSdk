using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群匿名状态
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="enable">是否启用匿名聊天</param>
public class CqSetGroupAnonymousAction(long groupId, bool enable) : CqAction
{

    /// <summary>
    /// 操作类型: 设置群匿名状态
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetGroupAnonymous;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 是否启用匿名聊天
    /// </summary>
    public bool Enable { get; set; } = enable;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetGroupAnonymousActionParamsModel(GroupId, Enable);
    }
}
