using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 消息上报上下文基类 (可以理解为上报信息的具体数据)
    /// </summary>
    public abstract record class CqPostContext
    {
        internal CqPostContext()
        {
            Time = DateTime.Now;
            Session = default!;         // 别警告了, 憨批 VS
                                     // 保证在 new 之后通过 SetSession 设置 Session
        }

        /// <summary>
        /// 当前上报的会话
        /// </summary>
        public CqSession Session { get; private set; }

        /// <summary>
        /// 上报类型
        /// </summary>
        public abstract CqPostType PostType { get; }

        /// <summary>
        /// 机器人 QQ ID
        /// </summary>
        public long SelfId { get; set; }

        /// <summary>
        /// 上报时间
        /// </summary>
        public DateTime Time { get; set; }

        internal abstract object? QuickOperationModel { get; }

        internal void SetSession(CqSession session)
        {
            Session = session;
        }

        internal static CqPostContext? FromModel(CqPostModel? model)
        {
            CqPostContext? cqEventArgs = model?.post_type switch
            {
                Consts.PostType.Message => FromMessageModel(model as CqMessagePostModel),
                Consts.PostType.Notice => FromNoticeModel(model as CqNoticePostModel),
                Consts.PostType.Request => FromRequestModel(model as CqRequestPostModel),
                Consts.PostType.MetaEvent => FromMetaModel(model as CqMetaPostModel),

                _ => null,
            };

            cqEventArgs?.ReadModel(model!);

            return cqEventArgs;
        }

        internal virtual void ReadModel(CqPostModel model)
        {
            Time = DateTimeOffset.FromUnixTimeSeconds(model.time).DateTime;
            SelfId = model.self_id;
        }

        private static CqPostContext? FromMessageModel(CqMessagePostModel? model)
        {
            return model?.message_type switch
            {
                Consts.MsgType.Private => new CqPrivateMessagePostContext(),
                Consts.MsgType.Group => new CqGroupMessagePostContext(),

                _ => null,
            };
        }

        private static CqPostContext? FromMetaModel(CqMetaPostModel? model)
        {
            return model?.meta_event_type switch
            {
                Consts.MetaEventType.Heartbeat => new CqHeartbeatPostContext(),
                Consts.MetaEventType.Lifecycle => new CqLifecyclePostContext(),

                _ => null
            };
        }

        private static CqPostContext? FromNoticeModel(CqNoticePostModel? model)
        {
            return model?.notice_type switch
            {
                Consts.NoticeType.Essence => new CqGroupEssenceChangedPostContext(),
                Consts.NoticeType.ClientStatus => new CqClientStatusChangedPostContext(),
                Consts.NoticeType.GroupUpload => new CqGroupFileUploadedPostContext(),
                Consts.NoticeType.GroupAdmin => new CqGroupAdministratorChangedPostContext(),
                Consts.NoticeType.GroupIncrease => new CqGroupMemberIncreasedPostContext(),
                Consts.NoticeType.GroupDecrease => new CqGroupMemberDecreasedPostContext(),
                Consts.NoticeType.GroupCard => new CqGroupMemberNicknameChangedPostContext(),
                Consts.NoticeType.GroupBan => new CqGroupMemberBanChangedPostContext(),
                Consts.NoticeType.GroupRecall => new CqGroupMessageRecalledPostContext(),
                Consts.NoticeType.FriendAdd => new CqFriendAddedPostContext(),
                Consts.NoticeType.FriendRecall => new CqFriendMessageRecalledPostContext(),
                Consts.NoticeType.OfflineFile => new CqOfflineFileUploadedPostContext(),

                Consts.NoticeType.Notify => FromNotifyModel(model),

                _ => null,
            };
        }

        private static CqPostContext? FromRequestModel(CqRequestPostModel? model)
        {
            return model?.request_type switch
            {
                Consts.RequestType.Friend => new CqFriendRequestPostContext(),
                Consts.RequestType.Group => new CqGroupRequestPostContext(),

                _ => null,
            };
        }

        private static CqPostContext? FromNotifyModel(CqPostModel? model)
        {
            if (model is not CqNoticeNotifyPostModel notifyModel)
                return null;

            return notifyModel.sub_type switch
            {
                Consts.NotifyType.Poke => new CqPokedPostContext(),
                Consts.NotifyType.LuckyKing => new CqGroupLuckyKingNoticedPostContext(),
                Consts.NotifyType.Honor => new CqGroupMemberHonorChangedPostContext(),
                Consts.NotifyType.Title => new CqGroupMemberTitleChangeNoticedPostContext(),

                _ => null,
            };
        }
    }
}
