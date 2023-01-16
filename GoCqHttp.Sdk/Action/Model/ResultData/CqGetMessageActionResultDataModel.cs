using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
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

        public bool group { get; set; }
        public long message_id { get; set; }
        public int real_id { get; set; }
        public CqMessageSenderModel sender { get; set; }
        public int time { get; set; }
        public CqMsgModel[] message { get; set; }
        public string raw_message { get; set; }
    }
}