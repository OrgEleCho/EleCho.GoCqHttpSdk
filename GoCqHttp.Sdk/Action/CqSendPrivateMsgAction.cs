using NullLib.GoCqHttpSdk.Action.Model.Params;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Action
{
    public class CqSendPrivateMsgAction : CqAction
    {
        public override string Type => Consts.ActionType.SendPrivateMsg;

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

        internal override CqActionParamsModel GetParamsModel() => new CqSendPrivateMsgActionParamsModel(UserId, GroupId, Array.ConvertAll(Message, CqMsg.ToModel), false);
    }
}