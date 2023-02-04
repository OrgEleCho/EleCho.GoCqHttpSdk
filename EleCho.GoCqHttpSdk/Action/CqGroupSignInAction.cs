using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGroupSignInAction : CqAction
    {
        public CqGroupSignInAction(long groupId)
        {
            GroupId = groupId;
        }

        public override CqActionType Type => CqActionType.GroupSignIn;

        public long GroupId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGroupSignInActionParamsModel(GroupId);
        }
    }
}
