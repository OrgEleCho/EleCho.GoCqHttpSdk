using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 重载事件过滤器操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="file">过滤器文件</param>
public class CqReloadEventFilterAction(string file) : CqAction
{

    /// <summary>
    /// 过滤器文件
    /// </summary>
    public string File { get; set; } = file;

    /// <summary>
    /// 操作类型: 重载事件过滤器
    /// </summary>
    public override CqActionType ActionType => CqActionType.ReloadEventFilter;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqReloadEventFilterActionParamsModel(File);
    }
}
