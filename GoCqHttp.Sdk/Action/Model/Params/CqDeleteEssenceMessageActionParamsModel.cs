using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqDeleteEssenceMessageActionParamsModel : CqActionParamsModel
    {
        public CqDeleteEssenceMessageActionParamsModel(long message_id)
        {
            this.message_id = message_id;
        }

        public long message_id { get; }
    }
}
