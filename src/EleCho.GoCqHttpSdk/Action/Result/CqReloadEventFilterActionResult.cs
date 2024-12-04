using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 重载事件过滤器操作结果
/// </summary>
public record class CqReloadEventFilterActionResult : CqActionResult
{
    internal CqReloadEventFilterActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}