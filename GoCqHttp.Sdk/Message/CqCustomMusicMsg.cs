using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 音乐自定义分享
    /// </summary>
    public class CqCustomMusicMsg : CqMusicMsg
    {
#pragma warning disable CS8618

        internal CqCustomMusicMsg() : base()
        {
        }

#pragma warning restore CS8618

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

        internal override CqMsgDataModel GetDataModel() => new CqCustomMusicMsgDataModel("custom", Url, Audio, Title, Content, Image);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqCustomMusicMsgDataModel;
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
}