using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 当前龙王
    /// </summary>
    public record class CqCurrentTalkative
    {
        internal CqCurrentTalkative(CqCurrentTalkativeModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Avatar = model.avatar;
            DayCount = model.day_count;
        }

        /// <summary>
        /// 构建当前龙王信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="nickname"></param>
        /// <param name="avatar"></param>
        /// <param name="dayCount"></param>
        [JsonConstructor]
        public CqCurrentTalkative(long userId, string nickname, string avatar, int dayCount)
        {
            UserId = userId;
            Nickname = nickname;
            Avatar = avatar;
            DayCount = dayCount;
        }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; } = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; } = string.Empty;

        /// <summary>
        /// 蝉联天数
        /// </summary>
        public int DayCount { get; }
    }
}
