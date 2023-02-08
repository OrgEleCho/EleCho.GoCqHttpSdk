using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetOnlineClientsAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.GetOnlineClients;

        public bool NoCache { get; set; }

        public CqGetOnlineClientsAction() : this(false)
        { }

        public CqGetOnlineClientsAction(bool noCache)
        {
            NoCache = noCache;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetOnlineClientsActionParamsModel(NoCache);
        }
    }
}
