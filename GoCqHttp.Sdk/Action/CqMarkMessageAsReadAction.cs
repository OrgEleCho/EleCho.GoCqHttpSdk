using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    internal class CqMarkMessageAsReadAction : CqAction
    {
        public override CqActionType Type => CqActionType.MarkMessageAsRead;

        internal override CqActionParamsModel GetParamsModel()
        {
            
        }
    }
}
