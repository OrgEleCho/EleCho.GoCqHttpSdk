using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    /// <summary>
    /// 用来匹配消息的扩展方法
    /// </summary>
    public static class CqPostSessionMessageMatchingExtensions
    {
        /// <summary>
        /// 匹配群消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UseGroupMessageMatch(this ICqPostSession session, string regex, Func<CqGroupMessagePostContext, Match, Func<Task>, Task> middleware)
        {
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            CqPostSessionExtensions.UseGroupMessage(session, async (context, next) =>
            {
                string text = context.Message.GetText();
                Match match = reg.Match(text);
                if (match.Success)
                {
                    await middleware.Invoke(context, match, next);
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配群消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UseGroupMessageMatch(this ICqPostSession session, string regex, Func<CqGroupMessagePostContext, Task> middleware)
        {
            CqPostSessionExtensions.UseGroupMessage(session, async (context, next) =>
            {
                if (Regex.IsMatch(context.Message.GetText(), regex))
                {
                    await middleware.Invoke(context);
                    await next.Invoke();
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配群消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UseGroupMessageMatch(this ICqPostSession session, string regex, Action<CqGroupMessagePostContext, Match, Func<Task>> middleware)
        {
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            CqPostSessionExtensions.UseGroupMessage(session, async (context, next) =>
            {
                string text = context.Message.GetText();
                Match match = reg.Match(text);
                if (match.Success)
                {
                    middleware.Invoke(context, match, next);
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配群消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UseGroupMessageMatch(this ICqPostSession session, string regex, Action<CqGroupMessagePostContext> middleware)
        {
            CqPostSessionExtensions.UseGroupMessage(session, async (context, next) =>
            {
                if (Regex.IsMatch(context.Message.GetText(), regex))
                {
                    middleware.Invoke(context);
                    await next.Invoke();
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配私聊消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UsePrivateMessageMatch(this ICqPostSession session, string regex, Func<CqPrivateMessagePostContext, Match, Func<Task>, Task> middleware)
        {
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            CqPostSessionExtensions.UsePrivateMessage(session, async (context, next) =>
            {
                string text = context.Message.GetText();
                Match match = reg.Match(text);
                if (match.Success)
                {
                    await middleware.Invoke(context, match, next);
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配私聊消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UsePrivateMessageMatch(this ICqPostSession session, string regex, Func<CqPrivateMessagePostContext, Task> middleware)
        {
            CqPostSessionExtensions.UsePrivateMessage(session, async (context, next) =>
            {
                if (Regex.IsMatch(context.Message.GetText(), regex))
                {
                    await middleware.Invoke(context);
                    await next.Invoke();
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配私聊消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UsePrivateMessageMatch(this ICqPostSession session, string regex, Action<CqPrivateMessagePostContext, Match, Func<Task>> middleware)
        {
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            CqPostSessionExtensions.UsePrivateMessage(session, async (context, next) =>
            {
                string text = context.Message.GetText();
                Match match = reg.Match(text);
                if (match.Success)
                {
                    middleware.Invoke(context, match, next);
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        /// <summary>
        /// 匹配私聊消息
        /// </summary>
        /// <param name="session">上报会话</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="middleware">中间件</param>
        public static void UsePrivateMessageMatch(this ICqPostSession session, string regex, Action<CqPrivateMessagePostContext> middleware)
        {
            CqPostSessionExtensions.UsePrivateMessage(session, async (context, next) =>
            {
                if (Regex.IsMatch(context.Message.GetText(), regex))
                {
                    middleware.Invoke(context);
                    await next.Invoke();
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        public static void UseMessageMatchPlugin(this ICqPostSession session, CqMessageMatchPostPlugin plugin)
        {
            session.UseAny(plugin.Execute);
        }
    }
}