using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取陌生人信息操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="userId">用户 QQ</param>
/// <param name="noCache">不使用缓存</param>
public class CqGetStrangerInformationAction(long userId, bool noCache) : CqAction
{
    /// <summary>
    /// 操作类型: 获取陌生人信息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetStrangerInformation;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    /// <summary>
    /// 实例化对象 (NoCache = false)
    /// </summary>
    /// <param name="userId">用户 QQ</param>
    public CqGetStrangerInformationAction(long userId) : this(userId, false)
    { }

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetStrangerInformationActionParamsModel(UserId, NoCache);
    }
}