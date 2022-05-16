using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendGroupForwardMsgAction : CqAction
    {
        public CqSendGroupForwardMsgAction(long groupId, CqForwardMsgNode[] messages)
        {
            GroupId = groupId;
            Messages = messages;
        }

        public override CqActionType Type => CqActionType.SendGroupForwardMsg;

        public long GroupId { get; set; }
        public CqForwardMsgNode[] Messages { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendGroupForwardMsgActionParamsModel(GroupId, Array.ConvertAll(Messages ?? Array.Empty<CqMsg>(), CqMsg.ToModel));
        }
    }
}