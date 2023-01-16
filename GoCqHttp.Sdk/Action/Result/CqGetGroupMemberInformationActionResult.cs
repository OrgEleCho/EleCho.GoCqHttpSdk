using EleCho.GoCqHttpSdk.Action.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupMemberInformationActionResult : CqActionResult
    {
        internal CqGetGroupMemberInformationActionResult() { }

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string GroupNickname { get; set; } = string.Empty;
        public CqGender Gender { get; set; }
        public string Area { get; set; } = string.Empty;
        public DateTime JoinTime { get; set; }
        public DateTime LastSentTime { get; set; }
        public string Level { get; set; } = string.Empty;
        public CqRole Role { get; set; }
        public bool Unfriendly { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime TitleExpireTime { get; set; }
        public bool GroupNicknameChangeable { get; set; }
        public DateTime BanExpireTime { get; set; }

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
