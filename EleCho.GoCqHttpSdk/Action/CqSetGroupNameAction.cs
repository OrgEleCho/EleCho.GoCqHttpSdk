using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群名操作
    /// </summary>
    public class CqSetGroupNameAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="groupName">群名</param>
        public CqSetGroupNameAction(long groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }

        /// <summary>
        /// 操作类型: 设置群名
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetGroupName;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        public string GroupName { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupNameActionParamsModel(GroupId, GroupName);
        }
    }
}
