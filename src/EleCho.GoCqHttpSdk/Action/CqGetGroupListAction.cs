using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群列表操作
/// </summary>
/// <remarks>
/// 创建实例
/// </remarks>
/// <param name="noCache">是否不使用缓存</param>
public class CqGetGroupListAction(bool noCache) : CqAction
{
    /// <summary>
    /// 操作类型: 获取群列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupList;

    /// <summary>
    /// 是否不使用缓存
    /// </summary>
    public bool NoCache { get; set; } = noCache;

    /// <summary>
    /// 创建实例  (NoCache = false)
    /// </summary>
    public CqGetGroupListAction() : this(false)
    { }

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupListActionParamsModel(NoCache);
    }
}
