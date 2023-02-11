using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群消息上报上下文
    /// </summary>
    public class CqGroupMessagePostQuickOperation : CqPostQuickOperation
    {
        /// <summary>
        /// 回复消息
        /// </summary>
        public CqMessage? Reply { get; set; }
        
        /// <summary>
        /// AT 发送者
        /// </summary>
        public bool AtSender { get; set; }

        /// <summary>
        /// 撤回
        /// </summary>
        public bool Recall { get; set; }

        /// <summary>
        /// 踢出群聊
        /// </summary>
        public bool Kick { get; set; }

        /// <summary>
        /// 禁言
        /// </summary>
        public bool Ban { get; set; }

        /// <summary>
        /// 禁言时间
        /// </summary>
        public TimeSpan BanDuration { get; set; }

        /// <summary>
        /// 因为内部不使用 CQ 码, 所以无用
        /// </summary>
        [Obsolete("在本 SDK 中此字段无用")]
        public bool AutoEscape { get; set; }

        internal override object? GetModel()
        {
            return new
            {
                reply = Reply == null ? null : Reply.Select(CqMsg.ToModel).ToArray(),
                at_sender = AtSender,
                delete = Recall,
                kick = Kick,
                ban = Ban,
                ban_duration = BanDuration.ToLongTotalSeconds(),
                // auto_escape  // 字段无用, 不传
            };
        }
    }
}