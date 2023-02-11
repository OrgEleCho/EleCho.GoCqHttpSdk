using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群昵称操作结果
    /// </summary>
    public class CqSetGroupNicknameActionResult : CqActionResult
    {
        internal CqSetGroupNicknameActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // no data
        }
    }
}
