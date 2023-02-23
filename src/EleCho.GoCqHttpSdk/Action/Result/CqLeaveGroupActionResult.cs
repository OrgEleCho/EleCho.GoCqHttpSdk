using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
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
}
