using NullLib.GoCqHttpSdk.Action.Model.Params;
using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Action
{
    public class CqSendMsgAction : CqAction
    {
        public CqSendMsgAction(long? userId, long? groupId, CqMsg[] message)
        {
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public CqSendMsgAction(CqMessageType messageType, long? userId, long? groupId, CqMsg[] message)
        {
            MessageType = messageType;
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public override string Type => Consts.ActionType.SendMsg;

        public CqMessageType MessageType { get; set; } = CqMessageType.Unknown;
        public long? UserId { get; set; }
        public long? GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [JsonIgnore]
        [Obsolete("该字段不可用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendMsgActionParamsModel(CqEnum.GetString(MessageType), UserId, GroupId, Array.ConvertAll(Message, CqMsg.ToModel));
        }
    }

    public class CqDeleteMsgAction : CqAction
    {
        public override string Type => Consts.ActionType.DeleteMsg;

        public int MessageId { get; set; }

        public CqDeleteMsgAction(int messageId) => MessageId = messageId;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteMsgActionParamsModel(MessageId);
        }
    }
}