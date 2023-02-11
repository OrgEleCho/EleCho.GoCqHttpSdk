using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetGroupInformationActionParamsModel : CqActionParamsModel
    {
        public CqGetGroupInformationActionParamsModel(long group_id, bool no_cache)
        {
            this.group_id = group_id;
            this.no_cache = no_cache;
        }

        public long group_id { get; }
        public bool no_cache { get; }
    }
}
