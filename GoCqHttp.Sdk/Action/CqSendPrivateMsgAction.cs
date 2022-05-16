using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.SendPrivateMsg;

        public CqSendPrivateMsgAction(long userId, long groupId, CqMsg[] message)
        {
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public long UserId { get; set; }
        public long GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel() => new CqSendPrivateMsgActionParamsModel(UserId, GroupId, Array.ConvertAll(Message ?? Array.Empty<CqMsg>(), CqMsg.ToModel), false);
    }
}