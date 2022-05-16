using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqHeartbeatPostContext : CqMetaEventPostContext
    {
        public override CqMetaType MetaEventType => CqMetaType.Heartbeat;

        public TimeSpan Interval { get; set; }

        internal CqHeartbeatPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaHeartbeatPostModel metaModel)
                return;

            Interval = new TimeSpan(metaModel.interval * TimeSpan.TicksPerMillisecond);
        }
    }
}