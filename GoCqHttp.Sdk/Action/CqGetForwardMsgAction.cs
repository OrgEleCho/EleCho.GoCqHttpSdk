using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetForwardMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetForwardMsg;

        public int MessageId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetForwardMsgActionParamsModel(MessageId);
        }
    }
}