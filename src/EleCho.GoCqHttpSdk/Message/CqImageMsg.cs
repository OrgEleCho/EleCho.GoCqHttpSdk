#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 图片消息段
    /// </summary>
    public record class CqImageMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: 图片
        /// </summary>
        public override string MsgType => Consts.MsgType.Image;

        /// <summary>
        /// 文件
        /// </summary>
        public string? File { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public CqImageType? ImageType { get; set; }

        /// <summary>
        /// 图片子类型
        /// </summary>
        public CqImageSubType ImageSubType { get; set; }

        /// <summary>
        /// 图片链接地址
        /// </summary>
        public Uri? Url { get; set; }

        /// <summary>
        /// 使用缓存
        /// </summary>
        public bool? UseCache { get; set; }

        /// <summary>
        /// 图片效果
        /// </summary>
        public CqImageEffect? ImageEffect { get; set; }

        /// <summary>
        /// 线程数
        /// </summary>
        public int? ThreadCount { get; set; }

        internal CqImageMsg()
        { }

        /// <summary>
        /// 构建图片消息段 (通过文件)
        /// </summary>
        /// <param name="file"></param>
        public CqImageMsg(string file)
        {
            File = file;
        }

        /// <summary>
        /// 构建图片消息段 (通过 URL 地址)
        /// </summary>
        /// <param name="url"></param>
        public CqImageMsg(Uri url)
        {
            Url = url;
        }

        internal string ImageTypeToString(CqImageType? cqImageType)
        {
            return cqImageType switch
            {
                CqImageType.Flash => "flash",
                CqImageType.Show => "show",
                _ => ""
            };
        }

        internal CqImageType ImageTypeFromString(string? value)
        {
            return value switch
            {
                "flash" => CqImageType.Flash,
                "show" => CqImageType.Show,
                _ => CqImageType.Unknown
            };
        }

        internal override CqMsgDataModel? GetDataModel() =>
            new CqImageMsgDataModel(File, ImageTypeToString(ImageType), ((int)ImageSubType).ToString(), Url?.ToString(), UseCache.ToInt(), (int?)ImageEffect, ThreadCount);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqImageMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            ImageType = ImageTypeFromString(m.type);
            ImageSubType = int.TryParse(m.subType, out int intsubtype) ? (CqImageSubType)intsubtype : CqImageSubType.Normal;
            UseCache = m.cache.ToBool();
            ImageEffect = (CqImageEffect?)m.id;
            ThreadCount = m.c;

            if (m.url != null)
                Url = new Uri(m.url);
        }
    }
}