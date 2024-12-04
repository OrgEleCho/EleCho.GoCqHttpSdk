using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取单向好友列表操作
/// </summary>
public class CqGetUnidirectionalFriendListAction : CqAction
{
    /// <summary>
    /// 操作类型: 获取单向好友列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetUnidirectionalFriendList;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetUnidirectionalFriendListActionParamsModel();
    }
}
