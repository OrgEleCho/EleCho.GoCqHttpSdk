using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置精华消息操作
    /// </summary>
    public class CqSetEssenceMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 设置精华消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.SetEssenceMessage;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId">消息 ID</param>
        public CqSetEssenceMessageAction(long messageId)
        {
            MessageId = messageId;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetEssenceMessageActionParamsModel(MessageId);
        }
    }
}
