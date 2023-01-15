using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqSendPrivateForwardMessageActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqSendPrivateForwardMessageActionResultDataModel(long message_id, string forward_id)
        {
            this.message_id = message_id;
            this.forward_id = forward_id;
        }

        public long message_id { get; set; }
        public string forward_id { get; set; }
    }
}