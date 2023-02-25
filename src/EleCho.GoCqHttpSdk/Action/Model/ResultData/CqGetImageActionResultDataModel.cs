using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetImageActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetImageActionResultDataModel(int size, string filename, string url)
        {
            this.size = size;
            this.filename = filename;
            this.url = url;
        }

        public int size { get; }
        public string filename { get; }
        public string url { get; }
    }
}