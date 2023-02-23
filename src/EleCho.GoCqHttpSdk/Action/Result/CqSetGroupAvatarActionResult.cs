using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群头像操作结果
    /// </summary>
    public record class CqSetGroupAvatarActionResult : CqActionResult
    {
        internal CqSetGroupAvatarActionResult()
        {
        }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // todo: check this
            // no data?
        }
    }
}
