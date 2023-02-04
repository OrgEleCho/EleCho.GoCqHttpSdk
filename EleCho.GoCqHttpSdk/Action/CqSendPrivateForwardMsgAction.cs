using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Message;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateForwardMsgAction : CqAction
    {
        public CqSendPrivateForwardMsgAction(long userId, CqForwardMessageNode[] messages)
        {
            UserId = userId;
            Messages = messages;
        }

        public override CqActionType ActionType => CqActionType.SendPrivateForwardMessage;

        public long UserId { get; set; }
        public CqForwardMessageNode[] Messages { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendPrivateForwardMsgActionParamsModel(UserId, Array.ConvertAll(Messages ?? Array.Empty<CqMsg>(), CqMsg.ToModel));
        }
    }
}