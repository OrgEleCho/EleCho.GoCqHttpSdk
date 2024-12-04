using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 退群操作结果
/// </summary>
public record class CqLeaveGroupActionResult : CqActionResult
{
    internal CqLeaveGroupActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
