using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendMessageActionParamsModel : CqActionParamsModel
    {
        public CqSendMessageActionParamsModel(string? message_type, long? user_id, long? group_id, CqMsgModel[] message)
        {
            this.message_type = message_type;
            this.user_id = user_id;
            this.group_id = group_id;
            this.message = message;
        }

        public string? message_type { get; }
        public long? user_id { get; }
        public long? group_id { get; }
        public CqMsgModel[] message { get; }

        [JsonIgnore]
        [Obsolete("传输协议使用 JSON, 所以该属性无用")]
        public bool auto_escape { get; }
    }
}