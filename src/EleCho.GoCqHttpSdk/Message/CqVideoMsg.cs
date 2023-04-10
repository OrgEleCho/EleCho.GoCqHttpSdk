using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 短视频消息段
    /// </summary>
    public record class CqVideoMsg : CqMsg
    {
        /// <summary>
        /// 消息段类型: 短视频
        /// </summary>
        public override string MsgType => Consts.MsgType.Video;

        /// <summary>
        /// 说明: 视频地址, 支持http和file发送
        /// </summary>
        public string File { get; set; } = string.Empty;

        /// <summary>
        /// 说明: 视频封面, 支持http, file和base64发送, 格式必须为jpg
        /// </summary>
        public string? Cover { get; set; }

        /// <summary>
        /// 说明: 通过网络下载视频时的线程数, 默认单线程. (在资源不支持并发时会自动处理)
        /// 可能的值: 2, 3
        /// </summary>
        public int? ThreadCount { get; set; }

        internal CqVideoMsg()
        { }

        /// <summary>
        /// 构建短视频消息段
        /// </summary>
        /// <param name="file">文件</param>
        public CqVideoMsg(string file) => File = file;

        internal override CqMsgDataModel? GetDataModel() => new CqVideoMsgDataModel(File, Cover, ThreadCount);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqVideoMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            File = m.file;
            Cover = m.cover;
            ThreadCount = m.c;
        }
    }
}