using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupMessagePostQuickOperation : CqPostQuickOperation
    {
        public CqMsg[]? Reply { get; set; }
        public bool AtSender { get; set; }
        public bool Recall { get; set; }
        public bool Kick { get; set; }
        public bool Ban { get; set; }
        public TimeSpan BanDuration { get; set; }

        [Obsolete("在本 SDK 中此字段无用")]
        public bool AutoEscape { get; set; }

        public override object? GetModel()
        {
            return new
            {
                reply = Reply != null ? Array.ConvertAll(Reply, CqMsg.ToModel) : null,
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