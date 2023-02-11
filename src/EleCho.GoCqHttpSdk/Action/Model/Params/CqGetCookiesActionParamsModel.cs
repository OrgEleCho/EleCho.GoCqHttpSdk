using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetCookiesActionParamsModel : CqActionParamsModel
    {
        public CqGetCookiesActionParamsModel(string domain)
        {
            this.domain = domain;
        }

        public string domain { get; } = string.Empty;
    }
}
