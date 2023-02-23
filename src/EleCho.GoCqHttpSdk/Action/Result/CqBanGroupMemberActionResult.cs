using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public record class CqBanGroupMemberActionResult : CqActionResult
    {
        internal CqBanGroupMemberActionResult() { }

        // no data

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {

        }
    }
}