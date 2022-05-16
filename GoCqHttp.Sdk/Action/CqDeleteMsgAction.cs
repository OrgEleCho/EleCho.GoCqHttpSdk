using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Util;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDeleteMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.DeleteMsg;

        public int MessageId { get; set; }

        public CqDeleteMsgAction(int messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteMsgActionParamsModel(MessageId);
        }
    }
}