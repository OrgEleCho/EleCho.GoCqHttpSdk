using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupNameAction : CqAction
    {
        public CqSetGroupNameAction(long groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }

        public override CqActionType Type => CqActionType.SetGroupName;

        public long GroupId { get; set; }
        public string GroupName { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupNameActionParamsModel(GroupId, GroupName);
        }
    }
}
