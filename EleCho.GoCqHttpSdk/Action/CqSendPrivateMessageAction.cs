using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateMessageAction : CqAction
    {
        public override CqActionType Type => CqActionType.SendPrivateMessage;

        public CqSendPrivateMessageAction(long userId, long groupId, params CqMsg[] message)
        {
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public CqSendPrivateMessageAction(long userId, params CqMsg[] message)
        {
            UserId = userId;
            Message = message;
        }

        public long UserId { get; set; }
        public long? GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [Obsolete("该属性无用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel() =>
#pragma warning disable CS0618 // Type or member is obsolete
            new CqSendPrivateMessageActionParamsModel(UserId, GroupId, Array.ConvertAll(Message ?? Array.Empty<CqMsg>(), CqMsg.ToModel), AutoEscape);
#pragma warning restore CS0618 // Type or member is obsolete

    }
}