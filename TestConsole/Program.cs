using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk;

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
            AssemblyTest.Run();

            string pluginCode = CqPostPluginCodeGen.Generate();


            return;

            Console.WriteLine("逻辑测试开始运行");
            var manyMiddlewares = new ManyMiddlewares(httpSession);

            session.UsePlugin(new MyPostPlugin());

            session.UseGroupMessage(manyMiddlewares.WaterWaterWater);
            session.UseGroupRequest(async (context, next) =>
            {
                await httpSession.ApproveGroupRequestAsync(context.Flag, context.SubRequestType);     // 自动同意群聊邀请
            });


            await session.ConnectAsync();

            await ApiTest.RunAsync(session);

            while (true)
                Console.ReadKey(true);
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
        }
    }
}