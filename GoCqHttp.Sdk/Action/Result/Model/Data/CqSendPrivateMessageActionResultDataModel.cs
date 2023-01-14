using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqSendPrivateMessageActionResultDataModel : CqSendMessageActionResultDataModel
    {
        [JsonConstructor]
        public CqSendPrivateMessageActionResultDataModel(long message_id) : base(message_id)
        {
        }
    }
}