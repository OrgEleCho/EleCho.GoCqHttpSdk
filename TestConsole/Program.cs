using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.DataStructure;

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
        static CqWsSession session = new CqWsSession(new CqWsSessionOptions()
        {
            BaseUri = new Uri("ws://127.0.0.1:5701"),
            UseApiEndPoint = true,
            UseEventEndPoint = true,
        });
        static CqHttpSession httpSession = new CqHttpSession(new CqHttpSessionOptions()
        {
            BaseUri = new Uri("http://127.0.0.1:5700"),
        });

        private static async Task Main(string[] args)
        {
            var 我的一堆中间件 = new ManyMiddlewares(httpSession);

            session.UsePlugin(new MyPostPlugin());

            //session.UseGroupMsgRecalled(async (context, next) =>              // 防撤回
            //{
            //    CqMsg[] message = (await session.GetMessage((int)context.MessageId))!.Message;
            //    await session.SendGroupMessageAsync(context.GroupId, CqMsg.Chain(new CqAtMessage(context.UserId), new CqTextMsg("发送了: ")).Concat(message).ToArray());
            //});

            session.UseGroupRequest(async (context, next) =>
            {
                await httpSession.ApproveGroupRequestAsync(context.Flag, context.SubRequestType);     // 自动同意群聊邀请
            });

            session.UseGroupMessage(我的一堆中间件.WaterWaterWater);

            await session.ConnectAsync();

            //rHttpSession.Start();

            while (true)
                Console.ReadKey(true);
        }
    }
}