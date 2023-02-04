using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetEssenceMessageAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.SetEssenceMessage;

        public long MessageId { get; set; }

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
