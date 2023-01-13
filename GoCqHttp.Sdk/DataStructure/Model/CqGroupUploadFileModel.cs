using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqGroupFileModel
    {
        [JsonConstructor]
        public CqGroupFileModel(string id, string name, long size, long busid)
        {
            this.id = id;
            this.name = name;
            this.size = size;
            this.busid = busid;
        }

        public string id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public long busid { get; set; }
    }
}