using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetCookiesActionResultDataModel(string cookies) : CqActionResultDataModel
{
    public string cookies { get; } = cookies;
}
