using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetMessage;

        public long MessageId { get; set; }

        public CqGetMessageAction(long messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetMessageActionParamsModel(MessageId);
        }
    }
}