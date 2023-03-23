using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群成员信息操作
    /// </summary>
    public class CqGetGroupMemberInformationAction : CqAction
    {
        /// <summary>
        /// 实例化对象 (NoCache = false)
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="userId">用户 QQ</param>
        public CqGetGroupMemberInformationAction(long groupId, long userId) : this(groupId, userId, false)
        { }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="userId">用户 ID</param>
        /// <param name="noCache">不使用缓存</param>
        public CqGetGroupMemberInformationAction(long groupId, long userId, bool noCache)
        {
            GroupId = groupId;
            UserId = userId;
            NoCache = noCache;
        }

        /// <summary>
        /// 操作类型: 获取群成员信息
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupMemberInformation;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 用户 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 不使用缓存
        /// </summary>
        public bool NoCache { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupMemberInformationActionParamsModel(GroupId, UserId, NoCache);
        }
    }
}
