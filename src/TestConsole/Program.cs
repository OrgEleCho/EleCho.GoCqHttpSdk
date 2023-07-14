using System;
using System.IO;
using System.Linq;
using System.Net.Http;
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

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        public const int WebSocketPort = 8080;

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

            session.UseMessageMatchPlugin(new MessageMatchPlugin1(session));

            session.UseGroupRequest(context =>
            {
                Console.WriteLine($"收到了加群请求{context}");
                context.QuickOperation.Approve = true;
            });

            session.UseGroupMessage(async context =>
            {
                string text = context.Message.Text.Trim();

                if (text.Equals("qwq", StringComparison.OrdinalIgnoreCase))
                    await session.SendGroupMessageAsync(context.GroupId, new CqMessage()
                    {
                        new CqReplyMsg(context.MessageId),
                        new CqTextMsg("qwq")
                    });

                if (text.StartsWith("#say", StringComparison.OrdinalIgnoreCase))
                    await session.SendGroupMessageAsync(context.GroupId, new CqMessage()
                    {
                        new CqRecordMsg(new Uri(@"C:\Users\slime\Documents\Sound Recordings\Recording (3).m4a")),
                    });

                if (text.StartsWith("#ban", StringComparison.OrdinalIgnoreCase))
                {
                    CqAtMsg? at = context.Message.OfType<CqAtMsg>().FirstOrDefault();

                    if (at != null)
                        await session.BanGroupMemberAsync(context.GroupId, at.Target, TimeSpan.FromSeconds(30));
                }


                if (text.StartsWith("#unban", StringComparison.OrdinalIgnoreCase))
                {
                    CqAtMsg? at = context.Message.OfType<CqAtMsg>().FirstOrDefault();

                    if (at != null)
                        await session.BanGroupMemberAsync(context.GroupId, at.Target, TimeSpan.Zero);
                }

                if (text.StartsWith("#fake", StringComparison.OrdinalIgnoreCase))
                {
                    await session.SendGroupForwardMessageAsync(context.GroupId,
                        new CqForwardMessage()
                        {
                            new CqForwardMessageNode("Hello", 123123123, CqMessage.FromCqCode("Hello")),
                        });
                }
            });

            //session.UseMessageMatchPlugin(new MessageMatchPlugin2(session));
            session.UseCommandExecutePlugin(new MyCommandExecutePlugin(session)
            {
                AtInvoker = true,
                ReplyInvoker = true,
                AllowGroupSelfMessage = true
            });

            Console.WriteLine("OK");
            await session.StartAsync();


            var qwq = await session.GetGroupMemberListAsync(560611514);
            var awa = await session.GetVersionInformationAsync();

            await Console.Out.WriteLineAsync(awa?.ToString());


            await session.WaitForShutdownAsync();
        }
    }

    class MyCommandExecutePlugin : CqCommandExecutePostPlugin
    {
        readonly HttpClient httpClient = new HttpClient();

        public MyCommandExecutePlugin(ICqActionSession actionSession)
        {
            ActionSession = actionSession;
        }

        public ICqActionSession ActionSession { get; }

        [Command]
        public double Add(double a, double b)
        {
            return a + b;
        }

        [Command]
        public double Pow(double x, double y = 2)
        {
            return Math.Pow(x, y);
        }

        [Command]
        public double Sum(params double[] nums)
        {
            return nums.Sum();
        }

        [Command]
        public async Task<CqMessage> GetAvatar(long userId)
        {
            var avatarStream = await httpClient.GetStreamAsync($"http://q1.qlogo.cn/g?b=qq&nk={userId}&s=100");

            return new CqMessage()
            {
                CqImageMsg.FromStream(avatarStream),
            };
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

        [CqMessageMatch("(男同)|(南通)")]
        public async Task Nantong(CqGroupMessagePostContext context)
        {
            var forwardMessage = new CqForwardMessage()
            {
                new CqForwardMessageNode(context.Sender.Nickname, context.UserId, new CqMessage("摊牌了, 我是男同!"))
            };

            foreach (var user in (await ActionSession.GetGroupMemberListAsync(context.GroupId))?.Members ?? Array.Empty<CqGroupMember>())
            {
                forwardMessage.Add(new CqForwardMessageNode(user.Nickname, user.UserId, new CqMessage("我超, 男同竟在我身边")));
            }

            await ActionSession.SendGroupForwardMessageAsync(context.GroupId, forwardMessage);
        }

        [CqMessageMatch("^#face (?<content>.*)")]
        public async Task Face(CqGroupMessagePostContext context, string content)
        {
            if (CqFaceMsg.FromName(content) is CqFaceMsg face)
                await ActionSession.SendGroupMessageAsync(context.GroupId, new CqMessage(face));
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