using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupMemberInformationAction : CqAction
    {
        public CqGetGroupMemberInformationAction(long groupId, long userId)
        {
            GroupId = groupId;
            UserId = userId;
            NoCache = false;
        }

        public CqGetGroupMemberInformationAction(long groupId, long userId, bool noCache)
        {
            GroupId = groupId;
            UserId = userId;
            NoCache = noCache;
        }

        public override CqActionType ActionType => CqActionType.GetGroupMemberInformation;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public bool NoCache { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupMemberInformationActionParamsModel(GroupId, UserId, NoCache);
        }
    }
}
