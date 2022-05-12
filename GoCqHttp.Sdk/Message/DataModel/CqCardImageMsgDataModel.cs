namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqCardImageMsgDataModel
    {
        public CqCardImageMsgDataModel() { }
        public CqCardImageMsgDataModel(string file, long? minwidth, long? minheight, long? maxwidth, long? maxheight, string? source, string? icon)
        {
            this.file = file;
            this.minwidth = minwidth;
            this.minheight = minheight;
            this.maxwidth = maxwidth;
            this.maxheight = maxheight;
            this.source = source;
            this.icon = icon;
        }

        public string file { get; set; }
        public long? minwidth { get; set; }
        public long? minheight { get; set; }
        public long? maxwidth { get; set; }
        public long? maxheight { get; set; }
        public string? source { get; set; }
        public string? icon { get; set; }
    }
}
