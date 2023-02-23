using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public record class CqDeleteUnidirectionalFriendActionResult : CqActionResult
    {
        internal CqDeleteUnidirectionalFriendActionResult()
        {
        }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // no data
        }
    }
}
