using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupAdministratorAction : CqAction
    {
        public CqSetGroupAdministratorAction(long groupId, long userId, bool enable)
        {
            GroupId = groupId;
            UserId = userId;
            Enable = enable;
        }

        public override CqActionType Type => CqActionType.SetGroupAdministrator;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public bool Enable { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAdministratorActionParamsModel(GroupId, UserId, Enable);
        }
    }
}
