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
        public override string Type => Consts.ActionType.SendMsg;

        public CqMessageType MessageType { get; set; }
        public long? UserId { get; set; }
        public long? GroupId { get; set; }
        public CqMsg[] Message { get; set; }

        [JsonIgnore]
        [Obsolete("该字段不可用")]
        public bool AutoEscape { get; set; }

        internal override CqActionParamsModel GetParamsModel() => throw new NotImplementedException();
    }
}