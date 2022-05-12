namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqImageMsgDataModel
    {
        public CqImageMsgDataModel()
        {
        }

        public CqImageMsgDataModel(string file, string? type, string? subType, string url, int? cache, int? id, int? c)
        {
            this.file = file;
            this.type = type;
            this.subType = subType;
            this.url = url;
            this.cache = cache;
            this.id = id;
            this.c = c;
        }

        public string file { get; set; }
        public string? type { get; set; }
        public string? subType { get; set; }
        public string url { get; set; }
        public int? cache { get; set; }
        public int? id { get; set; }
        public int? c { get; set; }
    }
}
