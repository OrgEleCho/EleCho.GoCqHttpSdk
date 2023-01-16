using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqSendPrivateMessageActionResultDataModel : CqSendMessageActionResultDataModel
    {
        [JsonConstructor]
        public CqSendPrivateMessageActionResultDataModel(long message_id) : base(message_id)
        {
        }
    }
}