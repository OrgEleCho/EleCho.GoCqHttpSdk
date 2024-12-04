using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 退群操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">要退的群的群号</param>
/// <param name="dismissGroup">解散群 (仅在是群主的情况下可用)</param>
public class CqLeaveGroupAction(long groupId, bool dismissGroup) : CqAction
{
    /// <summary>
    /// 实例化对象 (DismissGroup = false)
    /// </summary>
    /// <param name="groupId">要退的群的群号</param>
    public CqLeaveGroupAction(long groupId) : this(groupId, false)
    { }

    /// <summary>
    /// 操作类型: 退群
    /// </summary>
    public override CqActionType ActionType => CqActionType.LeaveGroup;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 解散群聊
    /// </summary>
    public bool DismissGroup { get; set; } = dismissGroup;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqLeaveGroupActionParamsModel(GroupId, DismissGroup);
    }
}
