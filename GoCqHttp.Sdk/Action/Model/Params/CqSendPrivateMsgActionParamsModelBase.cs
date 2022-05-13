using NullLib.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSendMsgActionParamsModel : CqActionParamsModel
    {
        public CqMsgModel[] message { get; set; }

        [JsonIgnore]
        [Obsolete("传输协议使用 JSON, 所以该属性无用")]
        public bool auto_escape { get; set; }
    }
}