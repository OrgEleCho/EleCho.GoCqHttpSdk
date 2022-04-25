using System;

namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqNoticeEventArgs : CqEventArgs
    {
        public override CqEventType EventType => CqEventType.Notice;
        public abstract CqNoticeType NoticeType { get; }

        internal static CqNoticeEventArgs FromModel(CqNoticeEventModel? model)
        {
            return model?.notice_type switch
            {
                _ => throw new ArgumentException()
            };
        }
    }
}
