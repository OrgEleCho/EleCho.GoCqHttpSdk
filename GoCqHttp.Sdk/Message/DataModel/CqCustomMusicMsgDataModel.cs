#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqCustomMusicMsgDataModel : CqMsgDataModel
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

        public static CqCustomMusicMsgDataModel FromCqCode(CqCode code)
        {
            return new CqCustomMusicMsgDataModel(
                code.GetString(nameof(type))!,
                code.GetString(nameof(url))!,
                code.GetString(nameof(audio))!,
                code.GetString(nameof(title))!,
                code.GetString(nameof(content)),
                code.GetString(nameof(image)));
        }
    }
}