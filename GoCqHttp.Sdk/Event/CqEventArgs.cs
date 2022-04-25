using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Event
{

    public abstract class CqEventArgs
    {
        public DateTime Time { get; set; }
        public abstract CqEventType EventType { get; }
        public long SelfId { get; set; }

        internal CqEventArgs()
        {
            Time = DateTime.Now;
        }

        internal virtual void ReadModel(CqEventModel model)
        {
            Time = UnixTime.DateFromUnix(model.time);
            SelfId = model.self_id;
        }
        internal virtual void WriteModel(CqEventModel model)
        {
            model.time = UnixTime.DateToUnix(Time);
            model.self_id = SelfId;
        }

        internal static CqEventArgs? MessageFromModel(CqMessageEventModel? model)
        {
            return model?.message_type switch
            {
                "private" => new CqMessagePrivateEventArgs(),
                "group" => new CqMessageGroupEventArgs(),

                _ => null,
            };
        }

        internal static CqEventArgs? NoticeFromModel(CqNoticeEventModel? model)
        {
            return model?.notice_type switch
            {
                "group_upload" => new CqNoticeGroupUploadEventArgs(),

                _ => null,
            };
        }


        internal static CqEventArgs? RequestFromModel(CqRequestEventModel? model)
        {
            return model?.request_type switch
            {
                "friend" => new CqRequestFriendEventArgs(),
                "group" => new CqRequestGroupEventArgs(),

                _ => null,
            };
        }


        internal static CqEventArgs? MetaFromModel(CqMetaEventModel? model)
        {
            return model?.meta_event_type switch
            {
                "heartbeat" => new CqMetaHeartbeatEventArgs(),
                "lifecycle" => new CqMetaLifecycleEventArgs(),

                _ => null
            };
        }

        internal static CqEventArgs? FromModel(CqEventModel? model)
        {
            return model.post_type switch
            {
                "message" => MessageFromModel(model as CqMessageEventModel),
                "notice" => NoticeFromModel(model as CqNoticeEventModel),
                "request" => RequestFromModel(model as CqRequestEventModel),
                "meta_event" => MetaFromModel(model as CqMetaEventModel),

                _ => null,
            };
        }
    }
}
