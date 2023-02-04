using EleCho.GoCqHttpSdk.Model;
using System.Text.Json;

namespace EleCho.GoCqHttpSdk.Action.Model
{
    internal class CqActionResultRaw : CqWsDataModel
    {
        public string status { get; set; }
        public int retcode { get; set; }
        public string? msg { get; set; }
        public string? wording { get; set; }
        public string? echo { get; set; }
        public JsonElement? data { get; set; }
    }
}