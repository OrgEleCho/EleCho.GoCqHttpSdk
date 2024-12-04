using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群信息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="noCache">不使用缓存</param>
public class CqGetGroupInformationAction(long groupId, bool noCache) : CqAction
{
    /// <summary>
    /// 实例化对象 (NoCache = false)
    /// </summary>
    /// <param name="groupId">群号</param>
    public CqGetGroupInformationAction(long groupId) : this(groupId, false)
    { }

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    /// <summary>
    /// 操作类型: 获取群信息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupInformation;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupInformationActionParamsModel(GroupId, NoCache);
    }
}
