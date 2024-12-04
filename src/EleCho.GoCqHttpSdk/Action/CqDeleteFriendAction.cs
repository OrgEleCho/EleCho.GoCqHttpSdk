using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 删除好友操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="userId">用户 QQ</param>
public class CqDeleteFriendAction(long userId) : CqAction
{

    /// <summary>
    /// 操作类型: 删除好友
    /// </summary>
    public override CqActionType ActionType => CqActionType.DeleteFriend;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDeleteFriendActionParamsModel(UserId);
    }
}
