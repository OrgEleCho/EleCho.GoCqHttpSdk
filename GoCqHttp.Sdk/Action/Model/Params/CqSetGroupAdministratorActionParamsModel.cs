using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupAdministratorActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupAdministratorActionParamsModel(long group_id, long user_id, bool enable)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.enable = enable;
        }

        public long group_id { get; set; }
        public long user_id { get; set; }
        public bool enable { get; set; }
    }
}
