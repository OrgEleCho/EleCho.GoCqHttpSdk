using EleCho.GoCqHttpSdk.Action.Model.ResultData;
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

        public long GroupId { get; private set; }
        public long UserId { get; private set; }
        public string Nickname { get; private set; } = string.Empty;
        public string GroupNickname { get; private set; } = string.Empty;
        public CqGender Gender { get; private set; }
        public string Area { get; private set; } = string.Empty;
        public DateTime JoinTime { get; private set; }
        public DateTime LastSentTime { get; private set; }
        public string Level { get; private set; } = string.Empty;
        public CqRole Role { get; private set; }
        public bool Unfriendly { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public DateTime TitleExpireTime { get; private set; }
        public bool GroupNicknameChangeable { get; private set; }
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
