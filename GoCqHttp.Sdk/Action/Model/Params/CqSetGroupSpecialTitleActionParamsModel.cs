using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupSpecialTitleActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupSpecialTitleActionParamsModel(long group_id, long user_id, string special_title, long duration)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.special_title = special_title;
            this.duration = duration;
        }

        public long group_id { get; set; }
        public long user_id { get; set; }
        public string special_title { get; set; }
        public long duration { get; set; }
    }
}
