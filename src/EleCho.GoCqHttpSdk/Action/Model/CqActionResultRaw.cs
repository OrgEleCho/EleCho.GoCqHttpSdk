using EleCho.GoCqHttpSdk.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model
{
    internal class CqActionResultRaw : CqWsDataModel
    {
        [JsonConstructor]
        public CqActionResultRaw(string status, int retcode, string? msg, string? wording, string? echo, JsonElement? data)
        {
            this.status = status;
            this.retcode = retcode;
            this.msg = msg;
            this.wording = wording;
            this.echo = echo;
            this.data = data;
        }

        public string status { get; set; }
        public int retcode { get; set; }
        public string? msg { get; set; }
        public string? wording { get; set; }
        public string? echo { get; set; }
        public JsonElement? data { get; set; }
    }
}