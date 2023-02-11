using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 退群操作
    /// </summary>
    public class CqLeaveGroupAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">要退的群的群号</param>
        public CqLeaveGroupAction(long groupId)
        {
            GroupId = groupId;
        }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">要退的群的群号</param>
        /// <param name="dismissGroup">解散群 (仅在是群主的情况下可用)</param>
        public CqLeaveGroupAction(long groupId, bool dismissGroup) : this(groupId)
        {
            DismissGroup = dismissGroup;
        }

        /// <summary>
        /// 操作类型: 退群
        /// </summary>
        public override CqActionType ActionType => CqActionType.LeaveGroup;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 解散群聊
        /// </summary>
        public bool DismissGroup { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqLeaveGroupActionParamsModel(GroupId, DismissGroup);
        }
    }
}
