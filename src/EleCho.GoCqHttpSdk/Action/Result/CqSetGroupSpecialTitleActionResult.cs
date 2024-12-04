using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 设置群荣誉操作结果
/// </summary>
public record class CqSetGroupSpecialTitleActionResult : CqActionResult
{
    internal CqSetGroupSpecialTitleActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
