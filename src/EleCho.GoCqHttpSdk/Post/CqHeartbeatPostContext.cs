
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 心跳包上报上下文
    /// </summary>
    public record class CqHeartbeatPostContext : CqMetaEventPostContext
    {
        /// <summary>
        /// 元事件类型: 心跳
        /// </summary>
        public override CqMetaEventType MetaEventType => CqMetaEventType.Heartbeat;

        /// <summary>
        /// 状态
        /// </summary>
        public CqStatus Status { get; set; } = new CqStatus();

        /// <summary>
        /// 间隔
        /// </summary>
        public TimeSpan Interval { get; set; }
        
        internal CqHeartbeatPostContext() { }

        internal override object? QuickOperationModel => null;
        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaHeartbeatPostModel metaModel)
                return;

            Status = new CqStatus(metaModel.status);
            Interval = new TimeSpan(metaModel.interval * TimeSpan.TicksPerMillisecond);
        }
    }
}