using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestConsole
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
                        private static ICqPostSession Use<IContext>(ICqPostSession session, Func<IContext, Func<Task>, Task> middleware) where IContext : CqPostContext
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
                
                            return session;
                        }

                        private static ICqPostSession Use<IContext>(ICqPostSession session, Action<IContext, Func<Task>> middleware) where IContext : CqPostContext
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
                
                            return session;
                        }

                        private static ICqPostSession Use<IContext>(ICqPostSession session, Func<IContext, Task> middleware) where IContext : CqPostContext
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
                
                            return session;
                        }

                        private static ICqPostSession Use<IContext>(ICqPostSession session, Action<IContext> middleware) where IContext : CqPostContext
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

                            return session;
                        }
                                
                        /// <summary>
                        /// 使用一个中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">中间件</param>
                        /// <returns>传入的上报会话</returns>
                        public static ICqPostSession UseMiddleware(this ICqPostSession session, CqPostMiddleware middleware)
                        {
                            session.PostPipeline.Use(middleware.Execute);
                            return session;
                        }
                                
                        /// <summary>
                        /// 使用一个插件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="plugin">插件</param>
                        /// <returns>传入的上报会话</returns>
                        public static ICqPostSession UsePlugin(this ICqPostSession session, CqPostPlugin plugin)
                        {
                            session.PostPipeline.Use(plugin.Execute);
                            return session;
                        }
                                
                        /// <summary>
                        /// 使用任何一个中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">中间件</param>
                        /// <returns>传入的上报会话</returns>
                        public static void UseAny(this ICqPostSession session, Func<CqPostContext, Func<Task>, Task> middleware) => Use(session, middleware);
                
                """);

            // 异步, 带有下一个中间件参数的
            string summary1 =
                """
                        /// <summary>
                        /// 使用一个能处理特定上报的中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">异步, 带有下一个中间件参数的中间件. async (context, next) => { }</param>
                        /// <returns>传入的上报会话</returns>
                """;

            // 同步, 带有下一个中间件参数的
            string summary2 =
                """
                        /// <summary>
                        /// 使用一个能处理特定上报的中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">同步, 带有下一个中间件参数的中间件. (context, next) => { }</param>
                        /// <returns>传入的上报会话</returns>
                """;

            // 异步, 不带有下一个中间件参数的
            string summary3 =
                """
                        /// <summary>
                        /// 使用一个能处理特定上报的中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">异步, 不带有下一个中间件参数的中间件. async context => { }</param>
                        /// <returns>传入的上报会话</returns>
                """;

            // 同步, 不带有下一个中间件参数的
            string summary4 =
                """
                        /// <summary>
                        /// 使用一个能处理特定上报的中间件
                        /// </summary>
                        /// <param name="session">上报会话</param>
                        /// <param name="middleware">同步, 不带有下一个中间件参数的中间件. context => { }</param>
                        /// <returns>传入的上报会话</returns>
                """;

            void AddMethodsForPostType(string postType)
            {
                sb.AppendLine(summary1);
                sb.AppendLine($"        public static ICqPostSession Use{postType}(this ICqPostSession session, Func<Cq{postType}PostContext, Func<Task>, Task> middleware) => Use(session, middleware);");
                sb.AppendLine(summary2);
                sb.AppendLine($"        public static ICqPostSession Use{postType}(this ICqPostSession session, Action<Cq{postType}PostContext, Func<Task>> middleware) => Use(session, middleware);");
                sb.AppendLine(summary3);
                sb.AppendLine($"        public static ICqPostSession Use{postType}(this ICqPostSession session, Func<Cq{postType}PostContext, Task> middleware) => Use(session, middleware);");
                sb.AppendLine(summary4);
                sb.AppendLine($"        public static ICqPostSession Use{postType}(this ICqPostSession session, Action<Cq{postType}PostContext> middleware) => Use(session, middleware);");
            }



            sb.AppendLine("        #region Message");
            foreach (string msgType in msgTypesInfo)
                AddMethodsForPostType(msgType);
            sb.AppendLine("        #endregion Message");


            sb.AppendLine();
            sb.AppendLine("        #region Notice");
            foreach (string noticeType in noticeTypesInfo)
                AddMethodsForPostType(noticeType);
            sb.AppendLine("        #endregion Notice");


            sb.AppendLine();
            sb.AppendLine("        #region Request");
            foreach (string requestType in requestTypesInfo)
                AddMethodsForPostType(requestType);
            sb.AppendLine("        #endregion Request");


            sb.AppendLine();
            sb.AppendLine("        #region MetaEvent");
            foreach (string metaeventType in metaeventTypesInfo)
                AddMethodsForPostType(metaeventType);
            sb.AppendLine("        #endregion MetaEvent");

            sb.AppendLine(
                """
                    }
                }
                """);

            return sb.ToString();
        }
    }
}
