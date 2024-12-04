using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 处理好友请求操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="flag">请求标志 (从好友请求上报中获取)</param>
/// <param name="approve">是否同意</param>
/// <param name="remark">备注</param>
public class CqHandleFriendRequestAction(string flag, bool approve, string? remark) : CqAction
{
    /// <summary>
    /// 操作类型: 处理好友请求
    /// </summary>
    public override CqActionType ActionType => CqActionType.HandleFriendRequest;

    /// <summary>
    /// 请求标志 (从好友请求上报中获取)
    /// </summary>
    public string Flag { get; set; } = flag;

    /// <summary>
    /// 是否同意
    /// </summary>
    public bool Approve { get; set; } = approve;

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; } = remark;


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqHandleFriendRequestActionParamsModel(Flag, Approve, Remark);
    }
}