using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 删除精华消息操作
    /// </summary>
    public class CqDeleteEssenceMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 删除精华消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.DeleteEssenceMessage;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId">要删除的精华消息 ID</param>
        public CqDeleteEssenceMessageAction(long messageId)
        {
            MessageId = messageId;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteEssenceMessageActionParamsModel(MessageId);
        }
    }
}
