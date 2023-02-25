using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            Console.Write("OpenAI API Key:\n> ");
            var apikey =
                Console.ReadLine()!;

            session.UseMessageMatchPlugin(new MessageMatchPlugin1(session));
            session.UseMessageMatchPlugin(new OpenAiMatchPlugin(session, apikey));
            session.UseMessageMatchPlugin(new MessageMatchPlugin2(session));

            session.UseGroupRequest(async context =>
            {
                await session.ApproveGroupRequestAsync(context.Flag, context.GroupRequestType);
            });

            session.UseGroupMessage(async context =>
            {
                Console.WriteLine($"{context.Sender.Nickname}: {context.Message.Text}");

                if (context.Message.Text.StartsWith("ocr ", StringComparison.OrdinalIgnoreCase))
                {
                    var img = context.Message.FirstOrDefault(x => x is CqImageMsg);
                    if (img is CqImageMsg imgmsg)
                    {
                        var ocrrst =
                            await session.OcrImageAsync(imgmsg.File);

                        if (ocrrst == null)
                            return;

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("OCR:");
                        foreach (var txtdet in ocrrst.Texts)
                            sb.AppendLine($"{txtdet.Text} Confidence:{txtdet.Confidence}");

                        await session.SendGroupMessageAsync(context.GroupId, new CqMessage(sb.ToString()));
                    }
                }

                if (context.Message.Text.EndsWith("..."))
                {
                    await session.SendGroupMessageAsync(context.GroupId, context.Message);
                }
            });

            Console.WriteLine("OK");
            await session.RunAsync();
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

    class OpenAiMatchPlugin : CqMessageMatchPostPlugin
    {
        public OpenAiMatchPlugin(ICqActionSession actionSession, string apikey)
        {
            Client = new HttpClient();
            ActionSession = actionSession;
            Apikey = apikey;
        }


        public HttpClient Client { get; }
        public ICqActionSession ActionSession { get; }
        public string Apikey { get; }


        public class davinci_result
        {
            public class davinci_result_choices
            {
                public string text { get; set; }
                public int index { get; set; }
                public object logprobs { get; set; }
                public string finish_reason { get; set; }
            }
            public class davinci_result_usage
            {
                public int prompt_tokens { get; set; }
                public int completion_tokens { get; set; }
                public int total_tokens { get; set; }
            }
            public string id { get; set; }
            public string @object { get; set; }
            public int created { get; set; }
            public string model { get; set; }
            public davinci_result_choices[] choices { get; set; }
            public davinci_result_usage usage { get; set; }
        }


        [CqMessageMatch("^davinci (?<prompt>.+)")]
        public async void Davinci(CqMessagePostContext context, string prompt)
        {
            var request =
                new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions")
                {
                    Headers =
                    {
                        { "Authorization", $"Bearer {Apikey}" }
                    },

                    Content = JsonContent.Create(
                        new
                        {
                            model = "text-davinci-003",
                            prompt = $"回答这句话: {prompt}\n",
                            max_tokens = 2048,
                            temperature = 0.5,
                        }),
                };

            var response = await Client.SendAsync(request);
            var davinci_rst = await response.Content.ReadFromJsonAsync<davinci_result>();

            if (davinci_rst == null)
                return;

            var davinci_rst_txt =
                string.Join(Environment.NewLine, davinci_rst.choices.Select(choice => choice.text)).Trim();

            if (context is CqGroupMessagePostContext groupContext)
            {
                await ActionSession.SendGroupMessageAsync(groupContext.GroupId, new CqMessage(davinci_rst_txt));
            }
            else if (context is CqPrivateMessagePostContext privateContext)
            {
                await ActionSession.SendPrivateMessageAsync(privateContext.UserId, new CqMessage(davinci_rst_txt));
            }
        }



        public async Task ImageEdit(CqMessagePostContext context)
        {

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