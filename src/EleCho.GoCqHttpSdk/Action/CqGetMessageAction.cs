using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取消息操作
    /// </summary>
    public class CqGetMessageAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取消息
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetMessage;

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; set; }

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="messageId">消息 ID</param>
        public CqGetMessageAction(long messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetMessageActionParamsModel(MessageId);
        }
    }
}