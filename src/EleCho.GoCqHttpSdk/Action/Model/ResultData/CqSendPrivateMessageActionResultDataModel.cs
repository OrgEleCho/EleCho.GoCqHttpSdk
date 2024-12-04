using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqSendPrivateMessageActionResultDataModel(long message_id) : CqSendMessageActionResultDataModel(message_id)
{
}