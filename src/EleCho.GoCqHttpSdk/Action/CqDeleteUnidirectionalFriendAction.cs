using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 删除单向好友操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="userId">用户 QQ</param>
public class CqDeleteUnidirectionalFriendAction(long userId) : CqAction
{

    /// <summary>
    /// 操作类型: 删除单向好友
    /// </summary>
    public override CqActionType ActionType => CqActionType.DeleteUnidirectionalFriend;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDeleteUnidirectionalFriendActionParamsModel(UserId);
    }
}
