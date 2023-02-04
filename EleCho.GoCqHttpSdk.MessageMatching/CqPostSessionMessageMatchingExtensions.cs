using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    public static class CqPostSessionMessageMatchingExtensions
    {
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

        public static void UseMessageMatchPlugin(this ICqPostSession session, CqMessageMatchPostPlugin plugin)
        {
            session.UseAny(plugin.Execute);
        }
    }
}