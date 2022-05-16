#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Util;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public class CqShareMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Share;

        internal CqShareMsg()
        { }

        public CqShareMsg(string url, string title)
        {
            Url = url;
            Title = title;
        }

        /// <summary>
        /// 说明: URL
        /// </summary>
        public string Url { get; set; }

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

        internal override CqMsgDataModel GetDataModel() => new CqShareMsgDataModel(Url, Title, Content, Image);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            var m = model as CqShareMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Url = m.url;
            Title = m.title;
            Content = m.content;
            Image = m.image;
        }
    }
}