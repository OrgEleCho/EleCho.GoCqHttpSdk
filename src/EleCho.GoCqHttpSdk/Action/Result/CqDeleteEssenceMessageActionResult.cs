using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// <inheritdoc/>
/// </summary>
public record class CqDeleteEssenceMessageActionResult : CqActionResult
{
    internal CqDeleteEssenceMessageActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}