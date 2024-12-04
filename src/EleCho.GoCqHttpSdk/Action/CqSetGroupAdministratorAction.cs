using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群管理员操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="userId">用户 QQ</param>
/// <param name="enable">任命/撤职</param>
public class CqSetGroupAdministratorAction(long groupId, long userId, bool enable) : CqAction
{

    /// <summary>
    /// 操作类型
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetGroupAdministrator;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 任命/撤职
    /// </summary>
    public bool Enable { get; set; } = enable;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetGroupAdministratorActionParamsModel(GroupId, UserId, Enable);
    }
}
