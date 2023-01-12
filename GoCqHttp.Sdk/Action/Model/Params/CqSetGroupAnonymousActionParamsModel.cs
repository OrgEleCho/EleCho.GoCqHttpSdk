using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupAnonymousActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupAnonymousActionParamsModel(long group_id, bool enable)
        {
            this.group_id = group_id;
            this.enable = enable;
        }

        public long group_id { get; set; }
        public bool enable { get; set; }
    }
}
