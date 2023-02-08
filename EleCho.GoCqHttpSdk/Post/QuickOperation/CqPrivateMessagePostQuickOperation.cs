using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqPrivateMessagePostQuickOperation : CqPostQuickOperation
    {
        public CqMessage? Reply { get; set; }

        [Obsolete("在本 SDK 中此字段无用")]
        public bool AutoEscape { get; set; }

        public override object? GetModel()
        {
            return new
            {
                reply = Reply == null ? null : Reply.Select(CqMsg.ToModel).ToArray()
                // auto_escape  // 字段无用, 不传
            };
        }
    }
}