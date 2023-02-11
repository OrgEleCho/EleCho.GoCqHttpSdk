using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 撤回消息操作
    /// </summary>
    public class CqRecallMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 撤回消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.RecallMessage;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId">要撤回的消息 ID</param>
        public CqRecallMessageAction(long messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqRecallMessageActionParamsModel(MessageId);
        }
    }
}