using EleCho.GoCqHttpSdk.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model;

[method: JsonConstructor]
internal class CqActionResultRaw(string status, int retcode, string? msg, string? wording, string? echo, JsonElement? data) : CqWsDataModel
{
    public string status { get; set; } = status;
    public int retcode { get; set; } = retcode;
    public string? msg { get; set; } = msg;
    public string? wording { get; set; } = wording;
    public string? echo { get; set; } = echo;
    public JsonElement? data { get; set; } = data;
}