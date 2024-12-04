using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 群全体禁言操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="enable">是否启用禁言</param>
public class CqBanGroupAllMembersAction(long groupId, bool enable) : CqAction
{

    /// <summary>
    /// 操作类型: 群全体禁言
    /// </summary>
    public override CqActionType ActionType => CqActionType.BanGroupAllMembers;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 是否启用禁言
    /// </summary>
    public bool Enable { get; set; } = enable;


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqBanGroupAllMembersActionParamsModel(GroupId, Enable);
    }
}