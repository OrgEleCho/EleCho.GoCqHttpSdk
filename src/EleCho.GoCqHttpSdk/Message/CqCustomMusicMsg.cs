
using EleCho.GoCqHttpSdk.Message.DataModel;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 自定义音乐分享消息段
    /// </summary>
    public record class CqCustomMusicMsg : CqMusicMsg
    {

        internal CqCustomMusicMsg() : base()
        {
        }


        /// <summary>
        /// 构建自定义音乐分享消息段
        /// </summary>
        /// <param name="url"></param>
        /// <param name="audio"></param>
        /// <param name="title"></param>
        public CqCustomMusicMsg(string url, string audio, string title) : base(CqMusicType.Custom, -1)
        {
            Url = url;
            Audio = audio;
            Title = title;
        }

        /// <summary>
        /// 说明: 表示音乐自定义分享
        /// </summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// 说明: 音乐 URL
        /// </summary>
        public string Audio { get; set; } = string.Empty;

        /// <summary>
        /// 说明: 标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

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

        internal override CqMsgDataModel? GetDataModel() => new CqCustomMusicMsgDataModel("custom", Url, Audio, Title, Content, Image);

        internal override void ReadDataModel(CqMsgDataModel? model)
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