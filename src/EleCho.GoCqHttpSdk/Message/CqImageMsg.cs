#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.IO;

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
        /// 图片
        /// </summary>
        public string? Image { get; set; }

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
        /// 线程数 <br/>
        /// 通过网络下载图片时的线程数, 默认单线程. (在资源不支持并发时会自动处理)
        /// </summary>
        public int? ThreadCount { get; set; }

        internal CqImageMsg()
        { }

        /// <summary>
        /// 构建图片消息段 <br/>
        /// - 如果你要发送本地的图片, 请使用 "file:///路径" 这样的格式, 或者使用 <see cref="FromFile(string)"/> <br/>
        /// - 如果你要发送一些存储在内存中的图片, 请使用 "base64://" 这样的格式, 或者使用 <see cref="FromBytes(byte[])"/> 与 <see cref="FromStream(Stream)"/>
        /// </summary>
        /// <param name="image">图片</param>
        public CqImageMsg(string image)
        {
            Image = image;
        }

        /// <summary>
        /// 构建图片消息段 (通过 URL 地址) <br/>
        /// 这个地址需要是网络 URL
        /// </summary>
        /// <param name="url"></param>
        public CqImageMsg(Uri url)
        {
            Url = url;
        }

        /// <summary>
        /// 从文件创建图片消息
        /// </summary>
        /// <param name="path">图片文件路径</param>
        /// <returns></returns>
        public static CqImageMsg FromFile(string path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));
            if (!Path.IsPathRooted(path))
                throw new ArgumentException("路径必须是绝对路径", nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException("指定的图片文件不存在", path);

            // 转为 file:///xxx
            return new CqImageMsg(new Uri(path).ToString());
        }

        /// <summary>
        /// 从字节数组创建图片消息
        /// </summary>
        /// <param name="bytes">存放图片数据的字节数组</param>
        /// <returns></returns>
        public static CqImageMsg FromBytes(byte[] bytes)
        {
            if (bytes is null)
                throw new ArgumentNullException(nameof(bytes));

            return new CqImageMsg($"base64://{Convert.ToBase64String(bytes)}");
        }

        /// <summary>
        /// 从流创建图片消息
        /// </summary>
        /// <param name="stream">包含图片数据的流</param>
        /// <returns></returns>
        public static CqImageMsg FromStream(Stream stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));
            
            if (!stream.CanRead)
                throw new ArgumentException("用于创建图片的流必须是可读的", nameof(stream));

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);

            return FromBytes(ms.ToArray());
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
            new CqImageMsgDataModel(Image, ImageTypeToString(ImageType), ((int)ImageSubType).ToString(), Url?.ToString(), UseCache.ToInt(), (int?)ImageEffect, ThreadCount);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqImageMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Image = m.file;
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