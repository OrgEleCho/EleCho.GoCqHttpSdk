using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupNicknameAction : CqAction
    {
        public CqSetGroupNicknameAction(long groupId, long userId, string? nickname)
        {
            GroupId = groupId;
            UserId = userId;
            Nickname = nickname;
        }

        public override CqActionType Type => CqActionType.SetGroupNickname;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string? Nickname { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupNicknameActionParamsModel(GroupId, UserId, Nickname);
        }
    }
}
