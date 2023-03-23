using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    /// <summary>
    /// The same as <seealso cref="CqGroupMemberModel"/>
    /// </summary>
    internal class CqGetGroupMemberInformationActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupMemberInformationActionResultDataModel(long group_id, long user_id, string nickname, string card, string sex, int age, string area, int join_time, int last_sent_time, string level, string role, bool unfriendly, string title, long title_expire_time, bool card_changeable, long shut_up_timestamp)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.nickname = nickname;
            this.card = card;
            this.sex = sex;
            this.age = age;
            this.area = area;
            this.join_time = join_time;
            this.last_sent_time = last_sent_time;
            this.level = level;
            this.role = role;
            this.unfriendly = unfriendly;
            this.title = title;
            this.title_expire_time = title_expire_time;
            this.card_changeable = card_changeable;
            this.shut_up_timestamp = shut_up_timestamp;
        }

        public long group_id { get; }
        public long user_id { get; }
        public string nickname { get; } = string.Empty;
        public string card { get; } = string.Empty;
        public string sex { get; } = string.Empty;
        public int age { get; }
        public string area { get; } = string.Empty;
        public int join_time { get; }
        public int last_sent_time { get; }
        public string level { get; } = string.Empty;
        public string role { get; } = string.Empty;
        public bool unfriendly { get; }
        public string title { get; } = string.Empty;
        public long title_expire_time { get; }
        public bool card_changeable { get; }
        public long shut_up_timestamp { get; }
    }
}
