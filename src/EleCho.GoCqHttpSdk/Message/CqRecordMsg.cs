using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

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
        /// 说明: 语音文件名
        /// </summary>
        public string? File { get; set; }

        /// <summary>
        /// 说明: 发送时可选, 默认 0, 设置为 1 表示变声
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Magic { get; set; }

        /// <summary>
        /// 说明: 语音 URL
        /// </summary>
        public Uri? Url { get; set; } = null;

        /// <summary>
        /// 说明: 只在通过网络 URL 发送时有效, 表示是否使用已缓存的文件, 默认 1
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Cache { get; set; }

        /// <summary>
        /// 说明: 只在通过网络 URL 发送时有效, 表示是否通过代理下载文件 ( 需通过环境变量或配置文件配置代理 ) , 默认 1
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Proxy { get; set; }

        /// <summary>
        /// 只在通过网络 URL 发送时有效, 单位秒, 表示下载网络文件的超时时间 , 默认不超时
        /// </summary>
        public int? Timeout { get; set; }

        internal CqRecordMsg()
        { }

        /// <summary>
        /// 构建语音消息段 (通过文件)
        /// </summary>
        /// <param name="file">语音消息文件</param>
        public CqRecordMsg(string file) => File = file;


        /// <summary>
        /// 构建语音消息段 (通过网络地址)
        /// </summary>
        /// <param name="url">URL</param>
        public CqRecordMsg(Uri url) => Url = url;

        internal override CqMsgDataModel? GetDataModel() =>
            new CqRecordMsgDataModel(File, Magic.ToNullableInt(), Url?.ToString(), Cache.ToNullableInt(), Proxy.ToNullableInt(), Timeout);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqRecordMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            Magic = m.magic.ToBool();
            Cache = m.cache.ToBool();
            Proxy = m.proxy.ToBool();
            Timeout = m.timeout;

            if (m.url != null)
                Url = new Uri(m.url);
        }
    }
}