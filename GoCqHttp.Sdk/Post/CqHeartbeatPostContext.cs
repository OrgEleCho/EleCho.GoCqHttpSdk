
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqHeartbeatPostContext : CqMetaEventPostContext
    {
        public override CqMetaEventType MetaEventType => CqMetaEventType.Heartbeat;

        public CqStatus Status { get; set; }

        public TimeSpan Interval { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CqHeartbeatPostContext() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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