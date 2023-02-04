using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqCheckUrlSafetyAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.CheckUrlSafety;

        public string Url { get; set; }

        public CqCheckUrlSafetyAction(string url)
        {
            Url = url;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqCheckUrlSafetyActionParamsModel(Url);
        }
    }
}
