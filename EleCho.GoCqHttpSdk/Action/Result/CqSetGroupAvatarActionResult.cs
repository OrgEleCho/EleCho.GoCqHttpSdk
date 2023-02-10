using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群头像
    /// </summary>
    public class CqSetGroupAvatarActionResult : CqActionResult
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
