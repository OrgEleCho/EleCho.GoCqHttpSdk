using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 设置精华消息操作结果
/// </summary>
public record class CqSetEssenceMessageActionResult : CqActionResult
{
    internal CqSetEssenceMessageActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}