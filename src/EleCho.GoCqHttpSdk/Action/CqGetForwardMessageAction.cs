using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取转发消息操作
    /// </summary>
    public class CqGetForwardMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取转发消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetForwardMessage;

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId">消息 ID</param>
        public CqGetForwardMessageAction(long messageId) => MessageId = messageId;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetForwardMessageActionParamsModel(MessageId);
        }
    }
}