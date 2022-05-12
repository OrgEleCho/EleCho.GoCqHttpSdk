namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqRecordMsgDataModel
    {
        internal CqRecordMsgDataModel() { }
        public CqRecordMsgDataModel(string file, int magic, string? url, int? cache, int? proxy, int? timeout)
        {
            this.file = file;
            this.magic = magic;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }

        public string file { get; set; }
        public int magic { get; set; }
        public string? url { get; set; }
        public int? cache { get; set; }
        public int? proxy { get; set; }
        public int? timeout { get; set; }
    }
}
