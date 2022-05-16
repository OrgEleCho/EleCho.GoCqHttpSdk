using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetMsg;

        public int MessageId { get; set; }

        public CqGetMsgAction(int messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetMsgActionParamsModel(MessageId);
        }
    }
}