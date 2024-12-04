using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 设置群名操作结果
/// </summary>
public record class CqSetGroupNameActionResult : CqActionResult
{
    internal CqSetGroupNameActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
