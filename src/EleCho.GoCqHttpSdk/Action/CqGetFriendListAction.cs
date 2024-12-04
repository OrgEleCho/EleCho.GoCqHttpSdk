using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取好友列表操作
/// </summary>
public class CqGetFriendListAction : CqAction
{
    /// <summary>
    /// 操作类型: 获取好友列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetFriendList;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetFriendListActionParamsModel();
    }
}
