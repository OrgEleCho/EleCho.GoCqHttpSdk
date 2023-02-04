using System;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.MessageMatching;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        public const int WebSocketPort = 5701; // orig 5701
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

            Console.WriteLine(CqPostSessionExtensionsCodeGen.Generate());
            Console.ReadLine();

            Console.WriteLine("逻辑测试开始运行");


            session.UseGroupMessageMatch(@"\[(?<content>.*?)\]", async (context, match, next) =>
            {
                await session.SendGroupMessageAsync(context.GroupId, $"Captured content: {match.Groups["content"].Value}, index: {match.Index}");
            });


            await session.RunAsync();
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
        }
    }
}