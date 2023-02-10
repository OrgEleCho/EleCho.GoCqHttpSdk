using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群匿名状态
    /// </summary>
    public class CqSetGroupAnonymousAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="enable">是否启用匿名聊天</param>
        public CqSetGroupAnonymousAction(long groupId, bool enable)
        {
            GroupId = groupId;
            Enable = enable;
        }

        /// <summary>
        /// 操作类型: 设置群匿名状态
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetGroupAnonymous;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 是否启用匿名聊天
        /// </summary>
        public bool Enable { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAnonymousActionParamsModel(GroupId, Enable);
        }
    }
}
