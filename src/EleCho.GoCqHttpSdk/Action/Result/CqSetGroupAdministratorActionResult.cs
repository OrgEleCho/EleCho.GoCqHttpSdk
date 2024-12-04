using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 设置群管理员操作结果
/// </summary>
public record class CqSetGroupAdministratorActionResult : CqActionResult
{
    internal CqSetGroupAdministratorActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
