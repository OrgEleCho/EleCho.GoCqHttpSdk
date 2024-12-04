using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetLoginInformationActionResultDataModel(long user_id, string nickname) : CqActionResultDataModel
{
    public long user_id { get; } = user_id;
    public string nickname { get; } = nickname;
}
