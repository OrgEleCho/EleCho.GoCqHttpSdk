using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqOfflineFileModel
    {
        [JsonConstructor]
        public CqOfflineFileModel(string name, long size, string url)
        {
            this.name = name;
            this.size = size;
            this.url = url;
        }

        public string name { get; set; }
        public long size { get; set; }
        public string url { get; set; }
    }
}