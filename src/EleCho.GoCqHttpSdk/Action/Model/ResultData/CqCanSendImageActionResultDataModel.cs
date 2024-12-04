using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqCanSendImageActionResultDataModel(bool yes) : CqActionResultDataModel
{
    public bool yes { get; } = yes;
}