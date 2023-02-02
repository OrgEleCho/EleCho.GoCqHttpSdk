using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqCurrentTalkative
    {
        internal CqCurrentTalkative(CqCurrentTalkativeModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Avatar = model.avatar;
            DayCount = model.day_count;
        }

        [JsonConstructor]
        public CqCurrentTalkative(long userId, string nickname, string avatar, int dayCount)
        {
            UserId = userId;
            Nickname = nickname;
            Avatar = avatar;
            DayCount = dayCount;
        }

        public long UserId { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public int DayCount { get; set; }
    }
}
