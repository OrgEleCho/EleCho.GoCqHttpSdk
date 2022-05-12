namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqShareMsgDataModel
    {
        internal CqShareMsgDataModel() { }
        public CqShareMsgDataModel(string url, string title, string? content, string? image)
        {
            this.url = url;
            this.title = title;
            this.content = content;
            this.image = image;
        }

        public string url { get; set; }
        public string title { get; set; }
        public string? content { get; set; }
        public string? image { get; set; }
    }
}
