using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取 Cookies 操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="domain">域</param>
public class CqGetCookiesAction(string domain) : CqAction
{
    /// <summary>
    /// 操作类型: 获取 Cookies
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetCookies;

    /// <summary>
    /// 域
    /// </summary>
    public string Domain { get; set; } = domain;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetCookiesActionParamsModel(Domain);
    }
}
