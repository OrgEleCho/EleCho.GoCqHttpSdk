using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    public record class CqCurrentTalkative
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

        public long UserId { get; }
        public string Nickname { get; } = string.Empty;
        public string Avatar { get; } = string.Empty;
        public int DayCount { get; }
    }
}
