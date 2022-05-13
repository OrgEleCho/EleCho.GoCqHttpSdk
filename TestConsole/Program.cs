using NullLib.GoCqHttpSdk;
using NullLib.GoCqHttpSdk.Message;
using NullLib.GoCqHttpSdk.Util;
using System;
using System.Threading.Tasks;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            GlobalConfig.WaitTimeout = TimeSpan.FromSeconds(30);

            CqWsSession session = new CqWsSession(new CqWsSessionOptions()
            {
                BaseUri = new Uri("ws://127.0.0.1:6700"),
                UseApiEndPoint = true,
                UseEventEndPoint = true,
            });

            session.UseGroupMsg(async (context, next) =>
            {
                Console.WriteLine(context.RawMessage);

                if (context.RawMessage.Contains("喵"))
                {
                    await session.SendGroupMsgAsync(context.GroupId, new CqTextMsg("喵喵喵?"));
                }
                if (context.RawMessage.Contains("热重载"))
                {
                    await session.SendGroupMsgAsync(context.GroupId, new CqTextMsg("好耶, C# 太棒惹!"));
                }
                if (context.RawMessage.Contains("亲我"))
                {
                    if (context.RawMessage.Contains("悄咪咪"))
                        await session.SendPrivateMsgAsync(context.UserId, new CqTextMsg("mua~"));
                    else
                        await session.SendGroupMsgAsync(context.GroupId, new CqAtMsg(context.UserId), new CqTextMsg("mua~"));
                }
                if (context.RawMessage.Contains("卖个萌"))
                {
                    string[] awa = new string[]
                    {
                        "才不要呢! 哼~",
                        "略略略, 我可是有底线的, 怎么可以随便卖萌呢?",
                        "咦惹, 你这人好奇怪欸, 怎么提出这么无理的请求",
                        "(拨打110) 喂? 是警察叔叔嘛, 这里有一个奇怪的人缠着我"
                    };

                    int randindex = new Random().Next(0, awa.Length);

                    await session.SendGroupMsgAsync(context.GroupId, new CqTextMsg(awa[randindex]));
                }

                await next();
            });

            await session.ConnectAsync();

            while (true)
                Console.ReadKey(true);
        }
    }
}