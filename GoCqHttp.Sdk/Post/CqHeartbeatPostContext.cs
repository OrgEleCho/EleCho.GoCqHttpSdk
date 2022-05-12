using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;
using System;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqHeartbeatPostContext : CqMetaEventPostContext
    {
        public override CqMetaType MetaEventType => CqMetaType.Heartbeat;

        public TimeSpan Interval { get; set; }

        internal CqHeartbeatPostContext() { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaHeartbeatPostModel metaModel)
                return;

            Interval = new TimeSpan(metaModel.interval * TimeSpan.TicksPerMillisecond);
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqMetaHeartbeatPostModel metaModel)
                return;

            metaModel.interval = Interval.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
