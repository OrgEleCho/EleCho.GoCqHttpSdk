using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqCheckUrlSafetyActionResultDataModel() : CqActionResultDataModel
{
    public int level { get; }
}
