using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
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
}
