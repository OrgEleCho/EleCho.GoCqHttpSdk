using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 处理群请求操作结果
/// </summary>
public record class CqHandleGroupRequestActionResult : CqActionResult
{
    internal CqHandleGroupRequestActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {

    }
}