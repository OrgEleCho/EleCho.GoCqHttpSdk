using System;
using NullLib.GoCqHttpSdk.Util;

namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqMetaEventArgs : CqEventArgs
    {
        public override CqEventType EventType => CqEventType.MetaEvent;
        public abstract CqMetaType MetaEventType { get; }
    }

    public class CqMetaHeartbeatEventArgs : CqMetaEventArgs
    {
        public override CqMetaType MetaEventType => CqMetaType.Heartbeat;

        public TimeSpan Interval { get; set; }

        internal CqMetaHeartbeatEventArgs() { }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaHeartbeatEventModel metaModel)
                return;

            Interval = new TimeSpan(metaModel.interval * TimeSpan.TicksPerMillisecond);
        }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqMetaHeartbeatEventModel metaModel)
                return;

            metaModel.interval = Interval.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }

    public class CqMetaLifecycleEventArgs : CqMetaEventArgs
    {
        public override CqMetaType MetaEventType => CqMetaType.Lifecycle;

        public CqLifecycleType LifecycleType { get; set; }

        internal CqMetaLifecycleEventArgs() { }

        internal static CqLifecycleType SubTypeFromString(string str)
        {
            return str switch
            {
                "enable" => CqLifecycleType.Enable,
                "disable" => CqLifecycleType.Disable,
                "connect" => CqLifecycleType.Connect,

                _ => CqLifecycleType.Unknown
            };
        }

        internal static string SubTypeToString(CqLifecycleType type)
        {
            return type switch
            {
                CqLifecycleType.Enable => "enable",
                CqLifecycleType.Disable => "disable",
                CqLifecycleType.Connect => "connect",

                _ => string.Empty
            };
        }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqMetaLifecycleEventModel metaModel)
                return;

            LifecycleType = SubTypeFromString(metaModel.sub_type);
        }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqMetaLifecycleEventModel metaModel)
                return;

            metaModel.sub_type = SubTypeToString(LifecycleType);
        }
    }
}
