using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 标记消息已读操作结果
/// </summary>
public record class CqMarkMessageAsReadActionResult : CqActionResult
{
    internal CqMarkMessageAsReadActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // pass
    }
}
