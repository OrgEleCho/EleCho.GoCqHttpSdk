using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群管理员操作
    /// </summary>
    public class CqSetGroupAdministratorAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="userId">用户 QQ</param>
        /// <param name="enable">任命/撤职</param>
        public CqSetGroupAdministratorAction(long groupId, long userId, bool enable)
        {
            GroupId = groupId;
            UserId = userId;
            Enable = enable;
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetGroupAdministrator;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 任命/撤职
        /// </summary>
        public bool Enable { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAdministratorActionParamsModel(GroupId, UserId, Enable);
        }
    }
}
