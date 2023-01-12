using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupNicknameActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupNicknameActionParamsModel(long group_id, long user_id, string? card)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.card = card;
        }

        public long group_id { get; set; }
        public long user_id { get; set; }
        public string? card { get; set; }
    }
}
