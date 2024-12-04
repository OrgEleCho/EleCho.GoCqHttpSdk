using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群成员列表操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="noCache">不使用缓存</param>
public class CqGetGroupMemberListAction(long groupId, bool noCache) : CqAction
{
    /// <summary>
    /// 操作类型: 获取群成员列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupMemberList;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    /// <summary>
    /// 实例化对象  (NoCache = false)
    /// </summary>
    /// <param name="groupId">群号</param>
    public CqGetGroupMemberListAction(long groupId) : this(groupId, false)
    { }

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupMemberListActionParamsModel(GroupId, NoCache);
    }
}
