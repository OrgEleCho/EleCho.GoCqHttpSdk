using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
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

            rWsSession.UseMessageMatchPlugin(new MessageMatchPlugin1(rWsSession));
            rWsSession.UseMessageMatchPlugin(new MessageMatchPlugin2(rWsSession));

            rWsSession.UseGroupMessage(async context =>
            {
                Console.WriteLine($"{context.Sender.Nickname}: {context.Message.Text}");

                if (context.Message.Text.StartsWith("ocr ", StringComparison.OrdinalIgnoreCase))
                {
                    var img = context.Message.FirstOrDefault(x => x is CqImageMsg);
                    if (img is CqImageMsg imgmsg)
                    {
                        var ocrrst =
                            await rWsSession.OcrImageAsync(imgmsg.File);

                        if (ocrrst == null)
                            return;

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("OCR:");
                        foreach (var txtdet in ocrrst.Texts)
                            sb.AppendLine($"{txtdet.Text} Confidence:{txtdet.Confidence}");

                        await rWsSession.SendGroupMessageAsync(context.GroupId, new CqMessage(sb.ToString()));
                    }
                }

                if (context.Message.Text.EndsWith("..."))
                {
                    await rWsSession.SendGroupMessageAsync(context.GroupId, context.Message);
                }
            });

            Console.WriteLine("OK");
            await rWsSession.RunAsync();
        }

        private static void CheckAssemblyTypes(Assembly asm)
        {
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
    }

    class MessageMatchPlugin2 : CqMessageMatchPostPlugin
    {
        public MessageMatchPlugin2(ICqActionSession actionSession)
        {
            ActionSession = actionSession;
        }

        public ICqActionSession ActionSession { get; }


        [CqMessageMatch("^repeat (?<content>.*)")]
        public async Task Echo(CqGroupMessagePostContext context, string content)
        {
            await ActionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(content));
        }
    }
}