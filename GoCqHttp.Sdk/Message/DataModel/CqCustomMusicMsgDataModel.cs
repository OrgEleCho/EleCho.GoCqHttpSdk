namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqCustomMusicMsgDataModel
    {
        public CqCustomMusicMsgDataModel()
        {
        }

        public CqCustomMusicMsgDataModel(string type, string url, string audio, string title, string? content, string? image)
        {
            this.type = type;
            this.url = url;
            this.audio = audio;
            this.title = title;
            this.content = content;
            this.image = image;
        }

        public string type { get; set; }
        public string url { get; set; }
        public string audio { get; set; }
        public string title { get; set; }
        public string? content { get; set; }
        public string? image { get; set; }
    }
}
