using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqLeaveGroupAction : CqAction
    {
        public CqLeaveGroupAction(long groupId)
        {
            GroupId = groupId;
        }

        public CqLeaveGroupAction(long groupId, bool dismissGroup) : this(groupId)
        {
            DismissGroup = dismissGroup;
        }

        public override CqActionType Type => CqActionType.LeaveGroup;

        public long GroupId { get; set; }
        public bool DismissGroup { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqLeaveGroupActionParamsModel(GroupId, DismissGroup);
        }
    }
}
