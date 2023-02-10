using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取精华消息列表操作
    /// </summary>
    public class CqGetEssenceMessageListAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取精华消息列表
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetEssenceMessagesList;

        /// <summary>
        /// 群号
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="groupId">群号</param>
        public CqGetEssenceMessageListAction(long groupId)
        {
            GroupId = groupId;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetEssenceMessageListActionParamsModel(GroupId);
        }
    }
}
