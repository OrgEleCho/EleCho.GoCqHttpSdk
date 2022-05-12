using NullLib.GoCqHttpSdk.Post;
using System;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public static class CqPostContextExtensions
    {
        private static void Use<IContext>(ICqPostSession session, Func<IContext, Func<Task>, Task> middleware) where IContext : CqPostContext
        {
            session.PostPipeline.Use(async (context, next) =>
            {
                if (context is IContext specifiedContext)
                {
                    await middleware(specifiedContext, next);
                }
                else
                {
                    await next();
                }
            });
        }

        public static void UseAny(this ICqPostSession session, Func<CqPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupMessage(this ICqPostSession session, Func<CqGroupMessagePostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UsePrivateMessage(this ICqPostSession session, Func<CqPrivateMessagePostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupFileUpload(this ICqPostSession session, Func<CqGroupFileUploadPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseClientStatusChanged(this ICqPostSession session, Func<CqClientStatusChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseEssenceChanged(this ICqPostSession session, Func<CqEssenceChangedPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseHeartbeat(this ICqPostSession session, Func<CqHeartbeatPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseLifecycle(this ICqPostSession session, Func<CqLifecyclePostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseFriendRequest(this ICqPostSession session, Func<CqFriendRequestPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
        public static void UseGroupRequest(this ICqPostSession session, Func<CqGroupRequestPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
    }
}
