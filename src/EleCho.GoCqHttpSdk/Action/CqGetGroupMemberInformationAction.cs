using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群成员信息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="userId">用户 ID</param>
/// <param name="noCache">不使用缓存</param>
public class CqGetGroupMemberInformationAction(long groupId, long userId, bool noCache) : CqAction
{
    /// <summary>
    /// 实例化对象 (NoCache = false)
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="userId">用户 QQ</param>
    public CqGetGroupMemberInformationAction(long groupId, long userId) : this(groupId, userId, false)
    { }

    /// <summary>
    /// 操作类型: 获取群成员信息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupMemberInformation;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupMemberInformationActionParamsModel(GroupId, UserId, NoCache);
    }
}
