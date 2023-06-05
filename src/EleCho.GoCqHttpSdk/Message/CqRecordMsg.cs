using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.IO;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 语音
    /// </summary>
    public record class CqRecordMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: 语音
        /// </summary>
        public override string MsgType => Consts.MsgType.Record;

        /// <summary>
        /// 语音
        /// </summary>
        public string? Record { get; set; }

        /// <summary>
        /// 发送时可选, 默认 0, 设置为 1 表示变声. <br/>
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Magic { get; set; }

        /// <summary>
        /// 语音 URL
        /// </summary>
        public Uri? Url { get; set; } = null;

        /// <summary>
        /// 只在通过网络 URL 发送时有效, 表示是否使用已缓存的文件, 默认 1. <br/>
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Cache { get; set; }

        /// <summary>
        /// 只在通过网络 URL 发送时有效, 表示是否通过代理下载文件 ( 需通过环境变量或配置文件配置代理 ) , 默认 1. <br/>
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Proxy { get; set; }

        /// <summary>
        /// 只在通过网络 URL 发送时有效, 单位秒, 表示下载网络文件的超时时间 , 默认不超时.
        /// </summary>
        public int? Timeout { get; set; }

        internal CqRecordMsg()
        { }

        /// <summary>
        /// 构建语音消息段 (通过文件) <br/>
        /// - 如果你想要发送一个接收到的语音, 可以在这里直接指定 <br/>
        /// - 如果你要发送一个本地文件, 需要使用 "file:///路径", 或者使用 <see cref="FromFile(string)"/> <br/>
        /// - 如果你要发送一个网络文件, 需要使用 "http://地址", 或者使用 <see cref="FromBytes(byte[])"/> 和 <see cref="FromStream(Stream)"/>
        /// </summary>
        /// <param name="record">语音消息文件</param>
        public CqRecordMsg(string record) => Record = record;


        /// <summary>
        /// 从文件创建语音消息
        /// </summary>
        /// <param name="path">语音文件路径</param>
        /// <returns></returns>
        public static CqRecordMsg FromFile(string path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));
            if (!Path.IsPathRooted(path))
                throw new ArgumentException("路径必须是绝对路径", nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException("指定的语音文件不存在", path);

            // 转为 file:///xxx
            return new CqRecordMsg(new Uri(path).ToString());
        }

        /// <summary>
        /// 从字节数组创建语音消息
        /// </summary>
        /// <param name="bytes">存放语音数据的字节数组</param>
        /// <returns></returns>
        public static CqRecordMsg FromBytes(byte[] bytes)
        {
            if (bytes is null)
                throw new ArgumentNullException(nameof(bytes));

            return new CqRecordMsg($"base64://{Convert.ToBase64String(bytes)}");
        }

        /// <summary>
        /// 从流创建语音消息
        /// </summary>
        /// <param name="stream">包含语音数据的流</param>
        /// <returns></returns>
        public static CqRecordMsg FromStream(Stream stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanRead)
                throw new ArgumentException("用于创建图片的流必须是可读的", nameof(stream));

            MemoryStream ms = new MemoryStream();
            stream.CopyTo(ms);

            return FromBytes(ms.ToArray());
        }

        /// <summary>
        /// 构建语音消息段 (通过网络地址)
        /// </summary>
        /// <param name="url">URL</param>
        public CqRecordMsg(Uri url) => Url = url;

        internal override CqMsgDataModel? GetDataModel() =>
            new CqRecordMsgDataModel(Record, Magic.ToNullableInt(), Url?.ToString(), Cache.ToNullableInt(), Proxy.ToNullableInt(), Timeout);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqRecordMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Record = m.file;
            Magic = m.magic.ToBool();
            Cache = m.cache.ToBool();
            Proxy = m.proxy.ToBool();
            Timeout = m.timeout;

            if (m.url != null)
                Url = new Uri(m.url);
        }
    }
}