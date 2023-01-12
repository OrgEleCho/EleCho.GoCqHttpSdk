using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqPostContext
    {
        internal CqPostContext()
        {
            Time = DateTime.Now;
        }

        public CqSession Session { get; private set; }

        public abstract CqPostType EventType { get; }
        public long SelfId { get; set; }
        public DateTime Time { get; set; }

        internal void SetSession(CqSession session)
        {
            Session = session;
        }

        internal static CqPostContext? FromModel(CqPostModel? model)
        {
            CqPostContext? cqEventArgs = model?.post_type switch
            {
                Consts.PostType.Message => MessageFromModel(model as CqMessagePostModel),
                Consts.PostType.Notice => NoticeFromModel(model as CqNoticePostModel),
                Consts.PostType.Request => RequestFromModel(model as CqRequestPostModel),
                Consts.PostType.MetaEvent => MetaFromModel(model as CqMetaPostModel),

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

        //internal virtual void WriteModel(CqPostModel model)
        //{
        //    model.time = UnixTime.DateToUnix(Time);
        //    model.self_id = SelfId;
        //}

        private static CqPostContext? MessageFromModel(CqMessagePostModel? model)
        {
            return model?.message_type switch
            {
                Consts.MsgType.Private => new CqPrivateMsgPostContext(),
                Consts.MsgType.Group => new CqGroupMessagePostContext(),

                _ => null,
            };
        }

        private static CqPostContext? MetaFromModel(CqMetaPostModel? model)
        {
            return model?.meta_event_type switch
            {
                Consts.MetaEventType.Heartbeat => new CqHeartbeatPostContext(),
                Consts.MetaEventType.Lifecycle => new CqLifecyclePostContext(),

                _ => null
            };
        }

        private static CqPostContext? NoticeFromModel(CqNoticePostModel? model)
        {
            return model?.notice_type switch
            {
                Consts.NoticeType.Essence => new CqEssenceChangedPostContext(),
                Consts.NoticeType.ClientStatus => new CqClientStatusChangedPostContext(),
                Consts.NoticeType.GroupUpload => new CqGroupFileUploadedPostContext(),
                Consts.NoticeType.GroupAdmin => new CqGroupAdminChangedPostContext(),
                Consts.NoticeType.GroupIncrease => new CqGroupMemberIncreasedPostContext(),
                Consts.NoticeType.GroupDecrease => new CqGroupMemberDecreasedPostContext(),
                Consts.NoticeType.GroupCard => new CqGroupMemberCardChangedPostContext(),
                Consts.NoticeType.GroupBan => new CqGroupBanChangedPostContext(),
                Consts.NoticeType.GroupRecall => new CqGroupMessageRecalledPostContext(),
                Consts.NoticeType.FriendAdd => new CqFriendAddedPostContext(),
                Consts.NoticeType.FriendRecall => new CqFriendMessageRecalledPostContext(),
                Consts.NoticeType.OfflineFile => new CqOfflineFileUploadedPostContext(),

                Consts.NoticeType.Notify => NotifyFromModel(model),

                _ => null,
            };
        }

        private static CqPostContext? RequestFromModel(CqRequestPostModel? model)
        {
            return model?.request_type switch
            {
                Consts.RequestType.Friend => new CqFriendRequestPostContext(),
                Consts.RequestType.Group => new CqGroupRequestPostContext(),

                _ => null,
            };
        }

        private static CqPostContext? NotifyFromModel(CqPostModel? model)
        {
            if (model is not CqNoticeNotifyPostModel notifyModel)
                return null;
            
            return notifyModel.sub_type switch
            {
                Consts.NotifyType.Poke => new CqPokedPostContext(),
                Consts.NotifyType.LuckyKing => new CqLuckyKingNoticedPostContext(),
                Consts.NotifyType.Honor => new CqHonorChangedPostContext(),

                _ => null,
            };
        }
    }
}