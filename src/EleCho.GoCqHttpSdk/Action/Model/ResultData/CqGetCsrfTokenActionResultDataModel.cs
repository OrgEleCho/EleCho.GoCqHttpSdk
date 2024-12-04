using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetCsrfTokenActionResultDataModel(int token) : CqActionResultDataModel
{
    public int token { get; } = token;
}
