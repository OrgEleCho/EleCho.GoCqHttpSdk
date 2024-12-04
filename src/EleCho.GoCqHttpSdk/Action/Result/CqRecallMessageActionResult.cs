using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 撤回消息操作结果
/// </summary>
public record class CqRecallMessageActionResult : CqActionResult
{
    internal CqRecallMessageActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    { }
}