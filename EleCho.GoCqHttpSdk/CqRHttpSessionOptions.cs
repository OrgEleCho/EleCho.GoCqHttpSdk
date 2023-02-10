using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 反向 HTTP 会话选项
    /// </summary>
    public struct CqRHttpSessionOptions
    {
        /// <summary>
        /// 基地址
        /// </summary>
        public Uri? BaseUri { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string? Secret { get; set; }
    }
}