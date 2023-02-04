using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupInformationAction : CqAction
    {
        public CqGetGroupInformationAction(long groupId)
        {
            GroupId = groupId;
            NoCache = false;
        }

        public CqGetGroupInformationAction(long groupId, bool noCache)
        {
            GroupId = groupId;
            NoCache = noCache;
        }

        public long GroupId { get; set; }
        public bool NoCache { get; set; }

        public override CqActionType ActionType => CqActionType.GetGroupInformation;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupInformationActionParamsModel(GroupId, NoCache);
        }
    }
}
