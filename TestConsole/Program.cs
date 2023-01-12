using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        static CqWsSession session;
        static CqHttpSession apiSession;

        private static async Task Main(string[] args)
        {
            session = new CqWsSession(new CqWsSessionOptions()
            {
                BaseUri = new Uri("ws://127.0.0.1:6700"),
                UseApiEndPoint = true,
                UseEventEndPoint = true,
            });

            apiSession = new CqHttpSession(new CqHttpSessionOptions()
            {
                BaseUri = new Uri("http://127.0.0.1:5700"),
            });

            var 我的一堆中间件 = new 一堆中间件(apiSession);

            session.UseGroupMsgRecalled(async (context, next) =>              // 防撤回
            {
                CqMsg[] message = (await session.GetMessage((int)context.MessageId))!.Message;
                await session.SendGroupMessageAsync(context.GroupId, CqMsg.Chain(new CqAtMessage(context.UserId), new CqTextMsg("发送了: ")).Concat(message).ToArray());
            });

            session.UseGroupRequest(async (context, next) =>
            {
                await apiSession.ApproveGroupRequest(context.Flag, context.SubRequestType);     // 自动同意群聊邀请
            });

            session.UseGroupMsg(我的一堆中间件.起哄中间件);

            await session.ConnectAsync();

            //rHttpSession.Start();

            while (true)
                Console.ReadKey(true);
        }
    }
}