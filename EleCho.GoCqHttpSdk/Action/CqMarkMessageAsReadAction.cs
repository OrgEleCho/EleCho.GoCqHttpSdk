using EleCho.GoCqHttpSdk.Action.Model.Params;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 标记消息已读操作
    /// </summary>
    public class CqMarkMessageAsReadAction : CqAction
    {
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId"></param>
        public CqMarkMessageAsReadAction(long messageId)
        {
            MessageId = messageId;
        }

        /// <summary>
        /// 操作类型: 标记消息已读
        /// </summary>
        public override CqActionType ActionType => CqActionType.MarkMessageAsRead;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqMarkMessageAsReadActionParamsModel(MessageId);
        }
    }
}
