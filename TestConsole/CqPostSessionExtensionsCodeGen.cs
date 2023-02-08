using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AssemblyCheck
{
    internal static class CqPostSessionExtensionsCodeGen
    {
        private static Type[] GetAllCqPostContextTypes()
        {
            Type baseType = typeof(CqPostContext);

            Assembly asm = baseType.Assembly;
            return asm.GetTypes()
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

        }

        public static string Generate()
        {
            List<string> msgTypesInfo = GetAllCqPostContextTypes()
                .Where(t => typeof(CqMessagePostContext).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name["Cq".Length..^("PostContext".Length)])
                .ToList();

            List<string> noticeTypesInfo = GetAllCqPostContextTypes()
                .Where(t => typeof(CqNoticePostContext).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name["Cq".Length..^("PostContext".Length)])
                .ToList();


            List<string> requestTypesInfo = GetAllCqPostContextTypes()
                .Where(t => typeof(CqRequestPostContext).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name["Cq".Length..^("PostContext".Length)])
                .ToList();

            List<string> metaeventTypesInfo = GetAllCqPostContextTypes()
                .Where(t => typeof(CqMetaEventPostContext).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name["Cq".Length..^("PostContext".Length)])
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                """
                using System;
                using System.Threading.Tasks;
                using EleCho.GoCqHttpSdk.Post;

                namespace EleCho.GoCqHttpSdk
                {

                    // 注意：这个文件是自动生成的，不要手动修改

                    /// <summary>
                    /// 上报会话的相关拓展方法
                    /// </summary>
                    public static class CqPostSessionExtensions
                    {
                        private static void Use<IContext>(ICqPostSession session, Func<IContext, Func<Task>, Task> middleware) where IContext : CqPostContext
                        {
                            session.PostPipeline.Use(async (context, next) =>
                            {
                                if(context is IContext specifiedContext)
                                {
                                    await middleware.Invoke(specifiedContext, next);
                                }
                                else
                                {
                                    await next.Invoke();
                                }
                            });
                        }

                        private static void Use<IContext>(ICqPostSession session, Action<IContext, Func<Task>> middleware) where IContext : CqPostContext
                        {
                            session.PostPipeline.Use(async (context, next) =>
                            {
                                if (context is IContext specifiedContext)
                                {
                                    middleware.Invoke(specifiedContext, next);
                                }
                                else
                                {
                                    await next.Invoke();
                                }
                            });
                        }

                        private static void Use<IContext>(ICqPostSession session, Func<IContext, Task> middleware) where IContext : CqPostContext
                        {
                            session.PostPipeline.Use(async (context, next) =>
                            {
                                if (context is IContext specifiedContext)
                                {
                                    await middleware.Invoke(specifiedContext);
                                    await next.Invoke();
                                }
                                else
                                {
                                    await next.Invoke();
                                }
                            });
                        }

                        private static void Use<IContext>(ICqPostSession session, Action<IContext> middleware) where IContext : CqPostContext
                        {
                            session.PostPipeline.Use(async (context, next) =>
                            {
                                if (context is IContext specifiedContext)
                                {
                                    middleware.Invoke(specifiedContext);
                                    await next.Invoke();
                                }
                                else
                                {
                                    await next.Invoke();
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
                
                """);

            sb.AppendLine(
                "        #region Message");
            foreach (string msgType in msgTypesInfo)
            {
                sb.AppendLine($"        public static void Use{msgType}(this ICqPostSession session, Func<Cq{msgType}PostContext, Func<Task>, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{msgType}(this ICqPostSession session, Action<Cq{msgType}PostContext, Func<Task>> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{msgType}(this ICqPostSession session, Func<Cq{msgType}PostContext, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{msgType}(this ICqPostSession session, Action<Cq{msgType}PostContext> middleware) => Use(session, middleware);");
            }
            sb.AppendLine(
            "        #endregion Message");


            sb.AppendLine();
            sb.AppendLine(
                "        #region Notice");
            foreach (string noticeType in noticeTypesInfo)
            {
                sb.AppendLine($"        public static void Use{noticeType}(this ICqPostSession session, Func<Cq{noticeType}PostContext, Func<Task>, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{noticeType}(this ICqPostSession session, Action<Cq{noticeType}PostContext, Func<Task>> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{noticeType}(this ICqPostSession session, Func<Cq{noticeType}PostContext, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{noticeType}(this ICqPostSession session, Action<Cq{noticeType}PostContext> middleware) => Use(session, middleware);");
            }
            sb.AppendLine(
            "        #endregion Notice");


            sb.AppendLine();
            sb.AppendLine(
                "        #region Request");
            foreach (string requestType in requestTypesInfo)
            {
                sb.AppendLine($"        public static void Use{requestType}(this ICqPostSession session, Func<Cq{requestType}PostContext, Func<Task>, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{requestType}(this ICqPostSession session, Action<Cq{requestType}PostContext, Func<Task>> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{requestType}(this ICqPostSession session, Func<Cq{requestType}PostContext, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{requestType}(this ICqPostSession session, Action<Cq{requestType}PostContext> middleware) => Use(session, middleware);");
            }
            sb.AppendLine(
            "        #endregion Request");


            sb.AppendLine();
            sb.AppendLine(
                "        #region MetaEvent");
            foreach (string metaeventType in metaeventTypesInfo)
            {
                sb.AppendLine($"        public static void Use{metaeventType}(this ICqPostSession session, Func<Cq{metaeventType}PostContext, Func<Task>, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{metaeventType}(this ICqPostSession session, Action<Cq{metaeventType}PostContext, Func<Task>> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{metaeventType}(this ICqPostSession session, Func<Cq{metaeventType}PostContext, Task> middleware) => Use(session, middleware);");
                sb.AppendLine($"        public static void Use{metaeventType}(this ICqPostSession session, Action<Cq{metaeventType}PostContext> middleware) => Use(session, middleware);");
            }
            sb.AppendLine(
            "        #endregion MetaEvent");

            sb.AppendLine(
                """
                    }
                }
                """);

            return sb.ToString();
        }
    }
}
