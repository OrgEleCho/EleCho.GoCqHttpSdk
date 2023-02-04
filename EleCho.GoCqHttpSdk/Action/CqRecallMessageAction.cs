using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqRecallMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.RecallMessage;

        public long MessageId { get; set; }

        public CqRecallMessageAction(long messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqRecallMessageActionParamsModel(MessageId);
        }
    }
}