using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetMessage;

        public int MessageId { get; set; }

        public CqGetMessageAction(int messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetMessageActionParamsModel(MessageId);
        }
    }
}