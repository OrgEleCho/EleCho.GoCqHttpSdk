using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetCookiesAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.GetCookies;

        public string Domain { get; set; } = string.Empty;

        public CqGetCookiesAction(string domain)
        {
            Domain = domain;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetCookiesActionParamsModel(Domain);
        }
    }
}
