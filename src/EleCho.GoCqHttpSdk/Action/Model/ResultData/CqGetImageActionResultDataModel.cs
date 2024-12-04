using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetImageActionResultDataModel(int size, string filename, string url) : CqActionResultDataModel
{
    public int size { get; } = size;
    public string filename { get; } = filename;
    public string url { get; } = url;
}