using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群成员信息操作结果
    /// </summary>
    public record class CqGetGroupMemberInformationActionResult : CqActionResult
    {
        internal CqGetGroupMemberInformationActionResult() { }


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

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetGroupMemberInformationActionResultDataModel m)
                throw new Exception();

            GroupId = m.group_id;
            UserId = m.user_id;
            Nickname = m.nickname;
            GroupNickname = m.card;

            Gender = CqEnum.GetGender(m.sex);
            Area = m.area;
            JoinTime = DateTimeOffset.FromUnixTimeSeconds(m.join_time).DateTime;
            LastSentTime = DateTimeOffset.FromUnixTimeSeconds(m.last_sent_time).DateTime;
            Level = m.level;
            Role = CqEnum.GetRole(m.role);
            Unfriendly = m.unfriendly;
            Title = m.title;
            TitleExpireTime = DateTimeOffset.FromUnixTimeSeconds(m.title_expire_time).DateTime;

            GroupNicknameChangeable = m.card_changeable;
            BanExpireTime = DateTimeOffset.FromUnixTimeSeconds(m.shut_up_timestamp).DateTime;
        }
    }
}
