using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Util;
using System;
using System.Linq;
using System.Threading.Tasks;

#nullable enable

namespace TestConsole
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            CqWsSession session = new CqWsSession(new CqWsSessionOptions()
            {
                BaseUri = new Uri("ws://127.0.0.1:6700"),
                UseApiEndPoint = true,
                UseEventEndPoint = true,
            });

            //CqRHttpSession rHttpSession = new CqRHttpSession(new CqRHttpSessionOptions()
            //{
            //    BaseUri = new Uri("http://127.0.0.1:1145"),
            //    AccessToken = "qwq",
            //});

            CqHttpSession apiSession = new CqHttpSession(new CqHttpSessionOptions()
            {
                BaseUri = new Uri("http://127.0.0.1:5700"),
            });

            //rHttpSession.UseGroupMsg(async (context, next) =>
            //{
            //    Console.WriteLine(context.RawMessage);
            //    await next();
            //});

            session.UseGroupMsgRecalled(async (context, next) =>
            {
                CqMsg[] message = (await session.GetMsg((int)context.MessageId)).Message;
                await session.SendGroupMsgAsync(context.GroupId, CqMsg.Chain(new CqAtMsg(context.UserId), new CqTextMsg("发送了: ")).Concat(message).ToArray());
            });

            session.UseGroupMsg(async (context, next) =>
            {
                string textMsg = context.Message.GetText();
                Console.WriteLine(textMsg);

                if (context.RawMessage.Contains("喵"))
                {
                    await apiSession.SendGroupMsgAsync(context.GroupId, new CqTextMsg("喵喵喵?"));
                }
                else if (context.RawMessage.Contains("热重载"))
                {
                    await apiSession.SendGroupMsgAsync(context.GroupId, new CqTextMsg("好耶, C# 太棒惹!"));
                }
                else if (context.RawMessage.Contains("亲我"))
                {
                    if (context.RawMessage.Contains("悄咪咪"))
                    {
                        await apiSession.SendPrivateMsgAsync(context.UserId, new CqTextMsg("mua~"));
                    }
                    else
                    {
                        var rst = await apiSession.SendGroupMsgAsync(context.GroupId, new CqAtMsg(context.UserId), new CqTextMsg("mua~"));
                    }
                }
                else if (context.RawMessage.Contains("骂我"))
                {
                    if (context.RawMessage.Contains("狠狠"))
                        await apiSession.SendPrivateMsgAsync(context.UserId, new CqTextMsg("cnm"));
                    else
                    {
                        string[] awa = new string[]
                        {
                            "恶心, 感谢我的大恩大德罢, 让你在我身边, 你应该觉得荣幸.",
                            "呵, 像你这样的死宅, 不会对纸片人做哪种奇怪的事情罢, 真恶心.",
                            "我已经无法忍受你在我身边了, 我建议你找个地缝钻进去"
                        };

#if DEBUG
                        context.GroupId++;
#endif

                        int randindex = new Random().Next(0, awa.Length);

                        var rst =  await apiSession.SendGroupMsgAsync(context.GroupId, new CqTextMsg(awa[randindex]));    // 发送脏话

                        await Task.Delay(2000);                                                                       // 等待 2 秒

                        if (rst != null && rst.Status == CqActionStatus.Okay)
                        {
                            await apiSession.DeleteMsgAsync(rst!.MessageId);                                             // 撤回消息
                            await apiSession.SendGroupMsgAsync(context.GroupId, new CqTextMsg("打错字惹qwq (小仙女怎么可以骂脏话呢)"));     // 发错了.jpg
                        }
                    }
                }
                else if (context.RawMessage.Contains("卖个萌"))
                {
                    string[] awa = new string[]
                    {
                        "才不要呢! 哼~",
                        "略略略, 我可是有底线的, 怎么可以随便卖萌呢?",
                        "咦惹, 你这人好奇怪欸, 怎么提出这么无理的请求",
                        "(拨打110) 喂? 是警察叔叔嘛, 这里有一个奇怪的人缠着我"
                    };

                    int randindex = new Random().Next(0, awa.Length);

                    await apiSession.SendMsgAsync(null, context.GroupId, new CqTextMsg(awa[randindex]));
                    //var rst =  await session.SendGroupMsgAsync(context.GroupId, new CqTextMsg(awa[randindex]));
                }
                else if (textMsg.Contains("假装卖萌"))
                {
                    CqMsg[] fakeMsg = CqMsg.CqCodeChain("嘤嘤嘤~");
                    await apiSession.SendGroupForwardMsg(context.GroupId,
                        new CqForwardMsgNode(context.Sender.Nickname, context.UserId, fakeMsg, fakeMsg));
                }
                else if (textMsg.Contains("转发测试"))
                {
                    await apiSession.SendGroupForwardMsg(context.GroupId,
                        new CqForwardMsgNode(context.MessageId));
                }
                else if (textMsg.StartsWith("="))
                {
                    await apiSession.SendGroupMsgAsync(context.GroupId, CqMsg.CqCodeChain(textMsg.Substring(1)));
                }

                await next();
            });

            await session.ConnectAsync();

            //rHttpSession.Start();

            while (true)
                Console.ReadKey(true);
        }
    }
}