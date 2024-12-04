using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqDownloadFileActionResultDataModel(string file) : CqActionResultDataModel
{
    public string file { get; } = file;
}
