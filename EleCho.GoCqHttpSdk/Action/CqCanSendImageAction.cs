using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqCanSendImageAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.CanSendImage;

        internal override CqActionParamsModel GetParamsModel() => new CqCanSendImageActionParamsModel();
    }
}
