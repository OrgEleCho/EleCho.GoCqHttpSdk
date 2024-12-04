using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqSendGroupForwardMessageActionResultDataModel(long message_id, string forward_id) : CqActionResultDataModel
{
    public long message_id { get; } = message_id;
    public string forward_id { get; } = forward_id;
}