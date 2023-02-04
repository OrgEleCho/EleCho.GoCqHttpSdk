using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetVersionInformationAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetVersionInformation;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetVersionInformationActionParamsModel();
        }
    }
}
