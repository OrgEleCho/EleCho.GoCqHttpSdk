using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDeleteFriendActionParamsModel : CqActionParamsModel
    {
        public CqDeleteFriendActionParamsModel(long user_id)
        {
            this.user_id = user_id;
        }

        public long user_id { get; set; }
    }
}
