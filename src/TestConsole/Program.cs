using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.CommandLine;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.CommandExecuting;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.MessageMatching;
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
        });

        private static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("OpenAI API Key:");
            string? apikey = Console.ReadLine();
            if (apikey == null)
                return;

            if (!string.IsNullOrWhiteSpace(apikey))
                session.UseMessageMatchPlugin(new OpenAiMatchPlugin(session, apikey));

            //session.UseMessageMatchPlugin(new MessageMatchPlugin2(session));
            session.UseCommandExecutePlugin(new MyCommandExecutePlugin());

            Console.WriteLine("OK");
            await session.RunAsync();
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {

        }
    }

    class MyCommandExecutePlugin : CqCommandExecutePostPlugin
    {
        [Command]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    class MessageMatchPlugin1 : CqMessageMatchPostPlugin
    {
        public MessageMatchPlugin1(ICqActionSession actionSession)
        {
            ActionSession = actionSession;
        }

        public ICqActionSession ActionSession { get; }


        [CqMessageMatch("^echo (?<content>.*)")]
        public async Task Echo(CqGroupMessagePostContext context, string content)
        {
            await ActionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(content));
        }

        [CqMessageMatch("^slide (?<content>.*)")]
        public async Task Slide(CqGroupMessagePostContext context, string content)
        {
            var slices =
                await ActionSession.GetWordSlicesAsync(content);
            if (slices == null)
                return;

            await ActionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(string.Join(", ", slices.Slices)));
        }

        [CqMessageMatch("^testFile (?<name>.*)")]
        public async Task TestFile(CqMessagePostContext context, string name)
        {
            var testContent =
                $"""
                现在时间: {DateTime.Now};
                随机 GUID: {Guid.NewGuid()}
                """;

            FileInfo fileInfo = new FileInfo(name);

            using (var file = fileInfo.OpenWrite())
            {
                using var writer = new StreamWriter(file);

                await writer.WriteAsync(testContent);
            }

            if (context is CqGroupMessagePostContext groupContext)
            {
                await ActionSession.UploadGroupFileAsync(groupContext.GroupId, fileInfo.FullName, name);
            }
            else if (context is CqPrivateMessagePostContext privateContext)
            {
                await ActionSession.UploadPrivateFileAsync(privateContext.UserId, fileInfo.FullName, name);
            }
        }
    }

    class MessageMatchPlugin2 : CqMessageMatchPostPlugin
    {
        public MessageMatchPlugin2(ICqActionSession actionSession)
        {
            ActionSession = actionSession;
        }

        public ICqActionSession ActionSession { get; }


        [CqMessageMatch(@"^repeat (?<content>.*)")]
        public async Task Echo(CqGroupMessagePostContext context, string qwq)
        {
            await ActionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(qwq));
        }
    }
}