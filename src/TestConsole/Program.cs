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
            CqRWsSession rWsSession = new CqRWsSession(new CqRWsSessionOptions()
            {
                BaseUri = new Uri("http://localhost:1234"),
                UseApiEndPoint = true,
                UseEventEndPoint = true,
            });

            rWsSession.UseGroupMessage(async context =>
            {
                Console.WriteLine($"{context.Sender.Nickname}: {context.Message.Text}");

                if (context.Message.Text.StartsWith("echo ", StringComparison.OrdinalIgnoreCase))
                    await rWsSession.SendGroupMessageAsync(context.GroupId, new CqMessage(context.Message.Text.Substring(5)));
            });

            Console.WriteLine("OK");
            await rWsSession.RunAsync();
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
        }
    }
}