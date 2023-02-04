using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDeleteFriendAction : CqAction
    {
        public CqDeleteFriendAction(long userId)
        {
            UserId = userId;
        }

        public override CqActionType Type => CqActionType.DeleteFriend;

        public long UserId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteFriendActionParamsModel(UserId);
        }
    }
}
