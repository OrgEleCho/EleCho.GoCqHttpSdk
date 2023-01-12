using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqMarkMessageAsReadActionParamsModel : CqActionParamsModel
    {
        public long message_id { get; set; }

        public CqMarkMessageAsReadActionParamsModel(long message_id)
        {
            this.message_id = message_id;
        }
    }
}
