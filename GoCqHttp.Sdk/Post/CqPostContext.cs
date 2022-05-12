using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Post
{

    public abstract class CqPostContext
    {
        internal CqPostContext()
        {
            Time = DateTime.Now;
        }

        public abstract CqPostType EventType { get; }
        public long SelfId { get; set; }
        public DateTime Time { get; set; }
        internal static CqPostContext? FromModel(CqPostModel? model)
        {
            CqPostContext? cqEventArgs = model?.post_type switch
            {
                "message" => MessageFromModel(model as CqMessagePostModel),
                "notice" => NoticeFromModel(model as CqNoticePostModel),
                "request" => RequestFromModel(model as CqRequestPostModel),
                "meta_event" => MetaFromModel(model as CqMetaPostModel),

                _ => null,
            };

            cqEventArgs?.ReadModel(model!);

            return cqEventArgs;
        }

        internal virtual void ReadModel(CqPostModel model)
        {
            Time = UnixTime.DateFromUnix(model.time);
            SelfId = model.self_id;
        }
        internal virtual void WriteModel(CqPostModel model)
        {
            model.time = UnixTime.DateToUnix(Time);
            model.self_id = SelfId;
        }

        private static CqPostContext? MessageFromModel(CqMessagePostModel? model)
        {
            return model?.message_type switch
            {
                "private" => new CqPrivateMsgPostContext(),
                "group" => new CqGroupMsgPostContext(),

                _ => null,
            };
        }

        private static CqPostContext? MetaFromModel(CqMetaPostModel? model)
        {
            return model?.meta_event_type switch
            {
                "heartbeat" => new CqHeartbeatPostContext(),
                "lifecycle" => new CqLifecyclePostContext(),

                _ => null
            };
        }

        private static CqPostContext? NoticeFromModel(CqNoticePostModel? model)
        {
            return model?.notice_type switch
            {
                "group_upload" => new CqGroupFileUploadPostContext(),

                _ => null,
            };
        }

        private static CqPostContext? RequestFromModel(CqRequestPostModel? model)
        {
            return model?.request_type switch
            {
                "friend" => new CqFriendRequestPostContext(),
                "group" => new CqGroupRequestPostContext(),

                _ => null,
            };
        }
    }
}
