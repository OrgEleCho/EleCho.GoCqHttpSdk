using NullLib.GoCqHttpSdk.Model;
using System.Text.Json;

namespace NullLib.GoCqHttpSdk.Action.Result.Model
{
    internal class CqActionResultRaw : CqWsDataModel
    {
        public string status { get; set; }
        public int retcode { get; set; }
        public string? echo { get; set; }
        public JsonElement? data { get; set; }
    }
}