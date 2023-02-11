using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetOnlineClientsActionParamsModel : CqActionParamsModel
    {
        public CqGetOnlineClientsActionParamsModel(bool no_cache)
        {
            this.no_cache = no_cache;
        }

        public bool no_cache { get; }
    }
}
