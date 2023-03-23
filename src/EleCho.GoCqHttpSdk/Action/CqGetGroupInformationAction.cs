using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群信息操作
    /// </summary>
    public class CqGetGroupInformationAction : CqAction
    {
        /// <summary>
        /// 实例化对象 (使用缓存)
        /// </summary>
        /// <param name="groupId">群号</param>
        public CqGetGroupInformationAction(long groupId) : this(groupId, false)
        { }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        /// <param name="noCache">不使用缓存</param>
        public CqGetGroupInformationAction(long groupId, bool noCache)
        {
            GroupId = groupId;
            NoCache = noCache;
        }

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 不使用缓存
        /// </summary>
        public bool NoCache { get; set; }

        /// <summary>
        /// 操作类型: 获取群信息
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupInformation;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupInformationActionParamsModel(GroupId, NoCache);
        }
    }
}
