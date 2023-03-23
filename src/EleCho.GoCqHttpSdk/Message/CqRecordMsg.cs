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
        public Uri File { get; set; } = new Uri("file:///");

        /// <summary>
        /// 说明: 发送时可选, 默认 0, 设置为 1 表示变声
        /// 可能的值: 0, 1
        /// </summary>
        public bool? Magic { get; set; }

        /// <summary>
        /// 说明: 语音 URL
        /// </summary>
        public string? Url { get; set; } = null;

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
        /// 创建语音消息
        /// </summary>
        /// <param name="file">语音消息文件 (网络或本地)</param>
        public CqRecordMsg(Uri file) => File = file;

        internal override CqMsgDataModel? GetDataModel() => new CqRecordMsgDataModel(File.ToString(), Magic.ToInt(), Url, Cache.ToInt(), Proxy.ToInt(), Timeout);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqRecordMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = new Uri(m.file);
            Magic = m.magic.ToBool();
            Url = m.url;
            Cache = m.cache.ToBool();
            Proxy = m.proxy.ToBool();
            Timeout = m.timeout;
        }
    }
}