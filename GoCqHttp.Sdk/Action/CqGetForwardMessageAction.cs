using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetForwardMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetForwardMessage;

        public CqGetForwardMessageAction(long messageId) => MessageId = messageId;

        public long MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetForwardMessageActionParamsModel(MessageId);
        }
    }
}