using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetCsrfTokenAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.GetCsrfToken;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetCsrfTokenActionParamsModel();
        }
    }
}
