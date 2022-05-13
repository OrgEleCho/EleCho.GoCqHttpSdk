using NullLib.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendMsgActionParamsModel : CqActionParamsModel
    {
        public CqSendMsgActionParamsModel()
        {
        }

        public CqSendMsgActionParamsModel(string? message_type, long? user_id, long? group_id, CqMsgModel[] message)
        {
            this.message_type = message_type;
            this.user_id = user_id;
            this.group_id = group_id;
            this.message = message;
        }

        public string? message_type { get; set; }
        public long? user_id { get; set; }
        public long? group_id { get; set; }
        public CqMsgModel[] message { get; set; }

        [JsonIgnore]
        [Obsolete("传输协议使用 JSON, 所以该属性无用")]
        public bool auto_escape { get; set; }
    }

    internal class CqDeleteMsgActionParamsModel : CqActionParamsModel
    {
        public CqDeleteMsgActionParamsModel()
        {
        }

        public CqDeleteMsgActionParamsModel(int message_id)
        {
            this.message_id = message_id;
        }

        public int message_id { get; set; }
    }
}