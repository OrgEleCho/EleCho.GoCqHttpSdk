using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 群签到操作
    /// </summary>
    public class CqGroupSignInAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        public CqGroupSignInAction(long groupId)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// 操作类型: 群签到
        /// </summary>
        public override CqActionType ActionType => CqActionType.GroupSignIn;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGroupSignInActionParamsModel(GroupId);
        }
    }
}
