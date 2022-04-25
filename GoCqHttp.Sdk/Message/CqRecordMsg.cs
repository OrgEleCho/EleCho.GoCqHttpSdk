using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 语音
    /// </summary>
    public class CqRecordMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Record;

        /// <summary>
        /// 说明: 语音文件名
        /// </summary>
        public string File { get; set; }

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


        internal CqRecordMsg() { }
        public CqRecordMsg(string file) => File = file;

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqRecordDataModel(File, Magic.ToInt(), Url, Cache.ToInt(), Proxy.ToInt(), Timeout));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqRecordDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            Magic = m.magic.ToBool();
            Url = m.url;
            Cache = m.cache.ToBool();
            Proxy = m.proxy.ToBool();
            Timeout = m.timeout;
        }
    }

    public class CqRecordDataModel
    {
        internal CqRecordDataModel() { }
        public CqRecordDataModel(string file, int magic, string? url, int? cache, int? proxy, int? timeout)
        {
            this.file = file;
            this.magic = magic;
            this.url = url;
            this.cache = cache;
            this.proxy = proxy;
            this.timeout = timeout;
        }

        public string file { get; set; }
        public int magic { get; set; }
        public string? url { get; set; }
        public int? cache { get; set; }
        public int? proxy { get; set; }
        public int? timeout { get; set; }
    }
}
