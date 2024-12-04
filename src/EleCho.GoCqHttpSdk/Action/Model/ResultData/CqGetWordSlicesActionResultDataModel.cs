using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetWordSlicesActionResultDataModel(string[] slices) : CqActionResultDataModel
{
    public string[] slices { get; } = slices;
}
