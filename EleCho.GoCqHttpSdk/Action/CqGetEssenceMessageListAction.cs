using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetEssenceMessageListAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.GetEssenceMessagesList;

        public long GroupId { get; set; }

        public CqGetEssenceMessageListAction(long groupId)
        {
            GroupId = groupId;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetEssenceMessageListActionParamsModel(GroupId);
        }
    }
}
