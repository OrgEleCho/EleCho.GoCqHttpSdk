using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 检查 URL 安全性操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="url">要检查的 URL</param>
public class CqCheckUrlSafetyAction(string url) : CqAction
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public override CqActionType ActionType => CqActionType.CheckUrlSafety;

    /// <summary>
    /// 要检查的 URL
    /// </summary>
    public string Url { get; set; } = url;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqCheckUrlSafetyActionParamsModel(Url);
    }
}
