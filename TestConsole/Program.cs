using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        public const int WebSocketPort = 5000; // orig 5701
        public const int HttpPort = 5700; //orig 5700

        static CqWsSession session = new CqWsSession(new CqWsSessionOptions()
        {
            BaseUri = new Uri($"ws://127.0.0.1:{WebSocketPort}"),
            UseApiEndPoint = true,
            UseEventEndPoint = true,
        });

        static CqHttpSession httpSession = new CqHttpSession(new CqHttpSessionOptions()
        {
            BaseUri = new Uri($"http://127.0.0.1:{HttpPort}"),
        });

        private static async Task Main(string[] args)
        {
            AssemblyTest.Run();

            Console.WriteLine("逻辑测试开始运行");
            var manyMiddlewares = new ManyMiddlewares(httpSession);

            session.UsePlugin(new MyPostPlugin());

            session.UseMemberTitleChanged(async (c, next) =>
            {
                await httpSession.SendGroupMessageAsync(c.GroupId, new CqTextMsg($"qwq这里是新加的title notify哦, 头衔是{c.NewTitle}"));
                await next();
            });
            session.UseGroupMessage(manyMiddlewares.WaterWaterWater);
            session.UseGroupRequest(async (context, next) =>
            {
                await httpSession.ApproveGroupRequestAsync(context.Flag, context.SubRequestType);     // 自动同意群聊邀请
            });


            await session.ConnectAsync();

            await ApiTest.RunAsync(session);

            while(true)
                Console.ReadKey(true);
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
        }
    }
}