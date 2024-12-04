using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取版本信息操作
/// </summary>
public class CqGetVersionInformationAction : CqAction
{
    /// <summary>
    /// 操作类型: 获取版本信息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetVersionInformation;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetVersionInformationActionParamsModel();
    }
}
