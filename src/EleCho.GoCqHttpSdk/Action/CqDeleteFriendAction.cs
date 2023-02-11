using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 删除好友操作
    /// </summary>
    public class CqDeleteFriendAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="userId">用户 QQ</param>
        public CqDeleteFriendAction(long userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// 操作类型: 删除好友
        /// </summary>
        public override CqActionType ActionType => CqActionType.DeleteFriend;

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteFriendActionParamsModel(UserId);
        }
    }
}
