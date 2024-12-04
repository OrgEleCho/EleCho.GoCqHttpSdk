using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置在线显示机型操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="model">机型</param>
/// <param name="modelShow">机型展示内容 (通过 GetModelShow 获取)</param>
public class CqSetModelShowAction(string model, string? modelShow) : CqAction
{

    /// <summary>
    /// 操作类型: 设置在线显示机型
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetModelShow;

    /// <summary>
    /// 机型
    /// </summary>
    public string Model { get; set; } = model;

    /// <summary>
    /// 机型展示内容
    /// </summary>
    public string? ModelShow { get; set; } = modelShow;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetModelShowActionParamsModel(Model, ModelShow);
    }
}
