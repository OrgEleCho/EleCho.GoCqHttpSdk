using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置账号资料操作结果
/// </summary>
public record class CqSetAccountProfileActionResult : CqActionResult
{
    internal CqSetAccountProfileActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
