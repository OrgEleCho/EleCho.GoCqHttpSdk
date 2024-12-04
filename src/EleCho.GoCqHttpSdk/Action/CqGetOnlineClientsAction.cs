using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取在线客户端操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="noCache">不使用缓存</param>
public class CqGetOnlineClientsAction(bool noCache) : CqAction
{
    /// <summary>
    /// 操作类型: 获取在线客户端
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetOnlineClients;

    /// <summary>
    /// 不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    /// <summary>
    /// 实例化对象 (NoCache = false)
    /// </summary>
    public CqGetOnlineClientsAction() : this(false)
    { }

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetOnlineClientsActionParamsModel(NoCache);
    }
}
