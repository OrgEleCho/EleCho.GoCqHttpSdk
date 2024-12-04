using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// <inheritdoc/>
/// </summary>
public record class CqDeleteFriendActionResult : CqActionResult
{
    internal CqDeleteFriendActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
