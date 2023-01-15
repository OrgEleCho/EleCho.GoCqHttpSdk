using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendGroupForwardMessageAction : CqAction
    {
        public CqSendGroupForwardMessageAction(long groupId, CqForwardMessageNode[] messages)
        {
            GroupId = groupId;
            Messages = messages;
        }

        public override CqActionType Type => CqActionType.SendGroupForwardMessage;

        public long GroupId { get; set; }
        public CqForwardMessageNode[] Messages { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendGroupForwardMsgActionParamsModel(GroupId, Array.ConvertAll(Messages ?? Array.Empty<CqMsg>(), CqMsg.ToModel));
        }
    }
}