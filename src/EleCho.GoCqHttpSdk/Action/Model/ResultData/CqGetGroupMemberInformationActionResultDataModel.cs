using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupMemberInformationActionResultDataModel : CqActionResultDataModel
    {
        public long group_id { get; set; }
        public long user_id { get; set; }
        public string nickname { get; set; } = string.Empty;
        public string card { get; set; } = string.Empty;
        public string sex { get; set; } = string.Empty;
        public int age { get; set; }
        public string area { get; set; } = string.Empty;
        public int join_time { get; set; }
        public int last_sent_time { get; set; }
        public string level { get; set; } = string.Empty;
        public string role { get; set; } = string.Empty;
        public bool unfriendly { get; set; }
        public string title { get; set; } = string.Empty;
        public long title_expire_time { get; set; }
        public bool card_changeable { get; set; }
        public long shut_up_timestamp { get; set; }
    }
}
