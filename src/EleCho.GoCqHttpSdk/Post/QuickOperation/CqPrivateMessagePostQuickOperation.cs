using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 私聊消息上报快速操作
    /// </summary>
    public class CqPrivateMessagePostQuickOperation : CqPostQuickOperation
    {
        /// <summary>
        /// 回复消息
        /// </summary>
        public CqMessage? Reply { get; set; }

        /// <summary>
        /// 因为内部不使用 CQ 码, 所以无用
        /// </summary>
        [Obsolete("在本 SDK 中此字段无用")]
        public bool AutoEscape { get; set; }

        internal override object? GetModel()
        {
            if (Reply == null)
                return null;

            return new
            {
                reply = Reply == null ? null : Reply.Select(CqMsg.ToModel).ToArray()
                // auto_escape  // 字段无用, 不传
            };
        }
    }
}