using System;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// WebSocket Session 选项
    /// </summary>
    public struct CqWsSessionOptions
    {
        /// <summary>
        /// 基础路径
        /// </summary>
        public Uri BaseUri { get; set; }
        /// <summary>
        /// 使用 /api 接入点
        /// </summary>
        public bool UseApiEndPoint { get; set; }
        /// <summary>
        /// 使用 /event 接入点
        /// </summary>
        public bool UseEventEndPoint { get; set; }

        /// <summary>
        /// 访问令牌 (鉴权用)
        /// </summary>
        public string? AccessToken { get; set; }
    }
}