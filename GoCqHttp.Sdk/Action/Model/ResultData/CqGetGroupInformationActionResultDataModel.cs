using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqGetGroupInformationActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupInformationActionResultDataModel(long group_id, string group_name, string group_memo, uint group_create_time, uint group_level, int member_count, int max_member_count)
        {
            this.group_id = group_id;
            this.group_name = group_name;
            this.group_memo = group_memo;
            this.group_create_time = group_create_time;
            this.group_level = group_level;
            this.member_count = member_count;
            this.max_member_count = max_member_count;
        }

        public long group_id { get; set; }
        public string group_name { get; set; } = string.Empty;
        public string group_memo { get; set; } = string.Empty;
        public uint group_create_time { get; set; }
        public uint group_level { get; set; }
        public int member_count { get; set; }
        public int max_member_count { get; set; }
    }
}
