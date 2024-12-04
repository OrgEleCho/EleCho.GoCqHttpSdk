using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取可用在线机型显示操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="model">机型</param>
public class CqGetModelShowAction(string model) : CqAction
{

    /// <summary>
    /// 操作类型: 获取可用在线机型显示
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetModelShow;

    /// <summary>
    /// 机型
    /// </summary>
    public string Model { get; set; } = model;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetModelShowActionParamsModel(Model);
    }
}
