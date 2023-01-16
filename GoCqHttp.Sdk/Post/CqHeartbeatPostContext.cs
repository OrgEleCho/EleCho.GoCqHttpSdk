
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 心跳包
    /// </summary>
    public class CqHeartbeatPostContext : CqMetaEventPostContext
    {
        public override CqMetaEventType MetaEventType => CqMetaEventType.Heartbeat;

        public CqStatus Status { get; set; } = new CqStatus();

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