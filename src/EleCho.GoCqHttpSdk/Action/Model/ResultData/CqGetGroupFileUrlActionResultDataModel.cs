using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupFileUrlActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupFileUrlActionResultDataModel(string url)
        {
            this.url = url;
        }

        public string url { get; }
    }
}
