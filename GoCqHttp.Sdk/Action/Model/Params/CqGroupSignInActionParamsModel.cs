using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGroupSignInActionParamsModel : CqActionParamsModel
    {
        public CqGroupSignInActionParamsModel(long group_id)
        {
            this.group_id = group_id;
        }

        public long group_id { get; set; }
    }
}
