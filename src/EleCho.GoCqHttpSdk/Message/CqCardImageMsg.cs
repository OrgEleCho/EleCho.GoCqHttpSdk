using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 一种xml的图片消息
    /// </summary>
    public record class CqCardImageMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: 卡片图片
        /// </summary>
        public override string MsgType => Consts.MsgType.CardImage;

        internal CqCardImageMsg()
        { }

        /// <summary>
        /// 构建卡片图片
        /// </summary>
        /// <param name="file"></param>
        public CqCardImageMsg(string file)
        {
            File = file;
        }

        /// <summary>
        /// 文件
        /// </summary>
        public string File { get; set; } = string.Empty;

        /// <summary>
        /// 最小宽度
        /// </summary>
        public long? MinWidth { get; set; }

        /// <summary>
        /// 最小高度
        /// </summary>
        public long? MinHeight { get; set; }

        /// <summary>
        /// 最大宽度
        /// </summary>
        public long? MaxWidth { get; set; }

        /// <summary>
        /// 最大高度
        /// </summary>
        public long? MaxHeight { get; set; }

        /// <summary>
        /// 源
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string? Icon { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqCardImageMsgDataModel(File, MinWidth, MinHeight, MaxWidth, MaxHeight, Source, Icon);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            if (model is not CqCardImageMsgDataModel m)
                throw new ArgumentException();

            File = m.file;
            MinWidth = m.minwidth;
            MinHeight = m.minheight;
            MaxWidth = m.maxwidth;
            MaxHeight = m.maxheight;
            Source = m.source;
            Icon = m.icon;
        }
    }
}