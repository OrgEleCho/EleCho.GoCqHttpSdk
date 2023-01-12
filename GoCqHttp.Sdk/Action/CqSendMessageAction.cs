using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendMessageAction : CqAction
    {
        public CqSendMessageAction(long? userId, long? groupId, CqMsg[] message)
        {
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public CqSendMessageAction(CqMessageType messageType, long? userId, long? groupId, CqMsg[] message)
        {
            MessageType = messageType;
            UserId = userId;
            GroupId = groupId;
            Message = message;
        }

        public override CqActionType Type => CqActionType.SendMessage;

        public CqMessageType MessageType { get; set; } = CqMessageType.Unknown;
        public long? UserId { get; set; }
        public long? GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [JsonIgnore]
        [Obsolete("该字段不可用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSendMessageActionParamsModel(CqEnum.GetString(MessageType), UserId, GroupId, Array.ConvertAll(Message, CqMsg.ToModel));
        }
    }
}