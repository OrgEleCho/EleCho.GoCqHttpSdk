using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    internal class CqSetGroupAnonymousAction : CqAction
    {
        public override CqActionType Type => CqActionType.SetGroupAnonymous;

        public long GroupId { get; set; }
        public bool Enable { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAnonymousActionParamsModel(GroupId, Enable);
        }
    }
}
