using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 群签到操作结果
/// </summary>
public record class CqGroupSignInActionResult : CqActionResult
{
    internal CqGroupSignInActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
