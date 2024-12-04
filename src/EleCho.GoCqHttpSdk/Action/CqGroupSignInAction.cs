using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 群签到操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
public class CqGroupSignInAction(long groupId) : CqAction
{

    /// <summary>
    /// 操作类型: 群签到
    /// </summary>
    public override CqActionType ActionType => CqActionType.GroupSignIn;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGroupSignInActionParamsModel(GroupId);
    }
}
