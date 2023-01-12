using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetForwardMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetForwardMessage;

        public CqGetForwardMessageAction(int messageId) => MessageId = messageId;

        public int MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetForwardMessageActionParamsModel(MessageId);
        }
    }
}