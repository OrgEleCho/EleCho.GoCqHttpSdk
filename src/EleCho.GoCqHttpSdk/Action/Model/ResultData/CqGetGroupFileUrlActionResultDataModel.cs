using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetGroupFileUrlActionResultDataModel(string url) : CqActionResultDataModel
{
    public string url { get; } = url;
}
