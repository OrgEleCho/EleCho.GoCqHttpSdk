using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群名操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="groupName">群名</param>
public class CqSetGroupNameAction(long groupId, string groupName) : CqAction
{

    /// <summary>
    /// 操作类型: 设置群名
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetGroupName;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 群名
    /// </summary>
    public string GroupName { get; set; } = groupName;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetGroupNameActionParamsModel(GroupId, GroupName);
    }
}
