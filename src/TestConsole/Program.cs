using System;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
//using EleCho.GoCqHttpSdk.MessageMatching;

#nullable enable

namespace AssemblyCheck
{
    internal class Program
    {
        public const int WebSocketPort = 5701;

        static CqWsSession session = new CqWsSession(new CqWsSessionOptions()
        {
            BaseUri = new Uri($"ws://127.0.0.1:{WebSocketPort}"),
            UseApiEndPoint = true,
            UseEventEndPoint = true,
        });

        private static async Task Main(string[] args)
        {
            CqSendPrivateMessageAction action = new CqSendPrivateMessageAction(114514, new CqMessage("qwq"));
            CqActionResult? rst = await session.ActionSender.InvokeActionAsync(action);
            CqSendPrivateMessageActionResult? msgRst = (CqSendPrivateMessageActionResult?)rst;

            session.PostPipeline.Use(async (context, next) =>
            {
                if (context is CqGroupMessagePostContext groupMessagePostContext)
                {
                    await session.SendGroupMessageAsync(groupMessagePostContext.GroupId, new CqMessage("检测到这个群发送了一条消息"));
                }
            });

            session.UseGroupMessage(async (context, next) =>
            {
                await session.SendGroupMessageAsync(context.GroupId, new CqMessage("检测到这个群发送了一条消息"));
            });

            Console.WriteLine(CqPostSessionExtensionsCodeGen.Generate());
            return;
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
        }
    }
}