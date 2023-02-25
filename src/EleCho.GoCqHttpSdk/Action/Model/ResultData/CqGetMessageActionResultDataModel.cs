using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetMessageActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetMessageActionResultDataModel(bool group, long message_id, int real_id, CqMessageSenderModel sender, int time, CqMsgModel[] message, string raw_message)
        {
            this.group = group;
            this.message_id = message_id;
            this.real_id = real_id;
            this.sender = sender;
            this.time = time;
            this.message = message;
            this.raw_message = raw_message;
        }

        public bool group { get; }
        public long message_id { get; }
        public int real_id { get; }
        public CqMessageSenderModel sender { get; }
        public int time { get; }
        public CqMsgModel[] message { get; }
        public string raw_message { get; }
    }
}