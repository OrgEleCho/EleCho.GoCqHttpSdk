#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqImageMsgDataModel : CqMsgDataModel
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

        public static CqImageMsgDataModel FromCqCode(CqCode code)
        {
            return new CqImageMsgDataModel(
                code.GetString(nameof(file))!,
                code.GetString(nameof(type)),
                code.GetString(nameof(subType)),
                code.GetString(nameof(url))!,
                code.GetInt(nameof(cache)),
                code.GetInt(nameof(id)),
                code.GetInt(nameof(c)));
        }
    }
}