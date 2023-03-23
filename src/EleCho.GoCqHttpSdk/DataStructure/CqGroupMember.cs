using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 群成员信息
    /// </summary>
    public record class CqGroupMember
    {
        internal CqGroupMember(CqGroupMemberModel model)
        {
            GroupId = model.group_id;
            UserId = model.user_id;
            Nickname = model.nickname;
            GroupNickname = model.card;
            Gender = CqEnum.GetGender(model.sex);
            Area = model.area;
            JoinTime = DateTimeOffset.FromUnixTimeSeconds(model.join_time).DateTime;
            LastSentTime = DateTimeOffset.FromUnixTimeSeconds(model.last_sent_time).DateTime;
            Level = model.level;
            Role = CqEnum.GetRole(model.role);
            Unfriendly = model.unfriendly;
            Title = model.title;
            TitleExpireTime = DateTimeOffset.FromUnixTimeSeconds(model.title_expire_time).DateTime;
            GroupNicknameChangeable = model.card_changeable;
            BanExpireTime = DateTimeOffset.FromUnixTimeSeconds(model.shut_up_timestamp).DateTime;
        }


        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; private set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; private set; } = string.Empty;

        /// <summary>
        /// 群昵称
        /// </summary>
        public string GroupNickname { get; private set; } = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        public CqGender Gender { get; private set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; private set; } = string.Empty;

        /// <summary>
        /// 加群时间
        /// </summary>
        public DateTime JoinTime { get; private set; }

        /// <summary>
        /// 上次发消息时间
        /// </summary>
        public DateTime LastSentTime { get; private set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; private set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public CqRole Role { get; private set; }

        /// <summary>
        /// 是否不良记录成员
        /// </summary>
        public bool Unfriendly { get; private set; }

        /// <summary>
        /// 群荣誉
        /// </summary>
        public string Title { get; private set; } = string.Empty;

        /// <summary>
        /// 群荣誉过期时间
        /// </summary>
        public DateTime TitleExpireTime { get; private set; }

        /// <summary>
        /// 可以更改群名片
        /// </summary>
        public bool GroupNicknameChangeable { get; private set; }

        /// <summary>
        /// 禁言过期时间
        /// </summary>
        public DateTime BanExpireTime { get; private set; }
    }
}
