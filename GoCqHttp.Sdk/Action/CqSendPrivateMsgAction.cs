using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateMsgAction : CqAction
    {
        public override CqActionType Type => CqActionType.SendPrivateMessage;

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

        internal override CqActionParamsModel GetParamsModel() => new CqSendPrivateMessageActionParamsModel(UserId, GroupId, Array.ConvertAll(Message ?? Array.Empty<CqMsg>(), CqMsg.ToModel), false);
    }
}