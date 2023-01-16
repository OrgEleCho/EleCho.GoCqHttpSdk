using EleCho.GoCqHttpSdk.Post;
using System;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public static class CqPostSessionExtensions
    {
        private static void Use<IContext>(ICqPostSession session, Func<IContext, Func<Task>, Task> middleware) where IContext : CqPostContext
        {
            session.PostPipeline.Use(async (context, next) =>
            {
                if(context is IContext specifiedContext)
                {
                    await middleware(specifiedContext, next);
                }
                else
                {
                    await next();
                }
            });
        }

        public static void UseMiddleware(this ICqPostSession session, CqPostMiddleware plugin)
        {
            session.PostPipeline.Use(plugin.Execute);
        }
        public static void UsePlugin(this ICqPostSession session, CqPostPlugin plugin)
        {
            session.PostPipeline.Use(plugin.Execute);
        }

        public static void UseAny(this ICqPostSession session, Func<CqPostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        public static void UseGroupMessage(this ICqPostSession session, Func<CqGroupMessagePostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UsePrivateMessage(this ICqPostSession session, Func<CqPrivateMessagePostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        #region Notice
        public static void UseClientStatusChanged(this ICqPostSession session, Func<CqClientStatusChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseEssenceChanged(this ICqPostSession session, Func<CqEssenceChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupAdminChanged(this ICqPostSession session, Func<CqGroupAdminChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupBanChanged(this ICqPostSession session, Func<CqGroupBanChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupFileUploaded(this ICqPostSession session, Func<CqGroupFileUploadedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupMemberCardChanged(this ICqPostSession session, Func<CqGroupMemberCardChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupMemberIncreased(this ICqPostSession session, Func<CqGroupMemberIncreasedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupMemberDecreased(this ICqPostSession session, Func<CqGroupMemberDecreasedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupMsgRecalled(this ICqPostSession session, Func<CqGroupMessageRecalledPostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        public static void UseFriendAdded(this ICqPostSession session, Func<CqFriendAddedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseFriendMsgRecalled(this ICqPostSession session, Func<CqFriendMessageRecalledPostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        public static void UseOfflineFileUploaded(this ICqPostSession session, Func<CqOfflineFileUploadedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        #region Notify - Sys

        #endregion
        public static void UseHonorChanged(this ICqPostSession session, Func<CqHonorChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseLuckyKingNoticed(this ICqPostSession session, Func<CqLuckyKingNoticedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UsePoked(this ICqPostSession session, Func<CqPokedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);

        public static void UseMemberTitleChanged(this ICqPostSession session, Func<CqMemberTitleChangeNoticedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        #endregion

        #region Request
        public static void UseFriendRequest(this ICqPostSession session, Func<CqFriendRequestPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupRequest(this ICqPostSession session, Func<CqGroupRequestPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        #endregion

        #region MetaEvent
        public static void UseHeartbeat(this ICqPostSession session, Func<CqHeartbeatPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseLifecycle(this ICqPostSession session, Func<CqLifecyclePostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        #endregion
    }
}