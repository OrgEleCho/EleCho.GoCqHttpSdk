using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupAnonymousAction : CqAction
    {
        public CqSetGroupAnonymousAction(long groupId, bool enable)
        {
            GroupId = groupId;
            Enable = enable;
        }

        public override CqActionType Type => CqActionType.SetGroupAnonymous;

        public long GroupId { get; set; }
        public bool Enable { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAnonymousActionParamsModel(GroupId, Enable);
        }
    }
}
