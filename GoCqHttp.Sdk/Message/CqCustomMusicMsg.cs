using System;
using static NullLib.GoCqHttpSdk.Message.CqMusicMsg;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 音乐自定义分享
    /// </summary>
    public class CqCustomMusicMsg : CqMusicMsg
    {

        internal CqCustomMusicMsg():base() { }
        public CqCustomMusicMsg(string url, string audio, string title) : base(CqMusicType.Custom, -1)
        {
            Url = url;
            Audio = audio;
            Title = title;
        }

        /// <summary>
        /// 说明: 表示音乐自定义分享
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 说明: 音乐 URL
        /// </summary>
        public string Audio { get; set; }

        /// <summary>
        /// 说明: 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 说明: 发送时可选, 内容描述
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 说明: 发送时可选, 图片 URL
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// 说明: 表示音乐自定义分享 (不可以设置)
        /// </summary>
        public override CqMusicType MusicType => CqMusicType.Custom;

        /// <summary>
        /// (不使用)
        /// </summary>
        public override long Id { get => base.Id; set => base.Id = value; }

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqCustomMusicDataModel("custom", Url, Audio, Title, Content, Image));

        internal override void ReadDataModel(object model)
        {
            var m = model as CqCustomMusicDataModel;
            if (m == null)
                throw new ArgumentException();

            Url = m.url;
            Audio = m.audio;
            Title = m.title;
            Content = m.content;
            Image = m.image;
            MusicType = GetMusicTypeFromString(m.type);
        }
    }

    internal class CqCustomMusicDataModel
    {
        public CqCustomMusicDataModel()
        {
        }

        public CqCustomMusicDataModel(string type, string url, string audio, string title, string? content, string? image)
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
