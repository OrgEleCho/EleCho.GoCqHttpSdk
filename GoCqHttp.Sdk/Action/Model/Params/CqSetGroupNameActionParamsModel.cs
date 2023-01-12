using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupNameActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupNameActionParamsModel(long group_id, string group_name)
        {
            this.group_id = group_id;
            this.group_name = group_name;
        }

        public long group_id { get; set; }
        public string group_name { get; set; }
    }
}
