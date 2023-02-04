using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetCookiesActionResult : CqActionResult
    {
        internal CqGetCookiesActionResult()
        {
        }

        public string Cookies { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetCookiesActionResultDataModel _m)
                throw new Exception();

            Cookies = _m.cookies;
        }
    }
}
