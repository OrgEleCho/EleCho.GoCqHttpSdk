#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqRecordMsgDataModel : CqMsgDataModel
    {
        public CqRecordMsgDataModel()
        { }

        public CqRecordMsgDataModel(string? file, int? magic, string? url, int? cache, int? proxy, int? timeout)
        {
            this.file = file;
            this.magic = magic;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }

        public string? file { get; set; }
        public int? magic { get; set; }
        public string? url { get; set; }
        public int? cache { get; set; }
        public int? proxy { get; set; }
        public int? timeout { get; set; }

        public static CqRecordMsgDataModel FromCqCode(CqCode code)
        {
            return new CqRecordMsgDataModel(
                code.GetString(nameof(file))!,
                code.GetInt(nameof(magic)).GetValueOrDefault(0),
                code.GetString(nameof(url)),
                code.GetInt(nameof(cache)),
                code.GetInt(nameof(proxy)),
                code.GetInt(nameof(timeout)));
        }
    }
}