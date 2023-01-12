using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestConsole
{
    internal class ManyMiddlewares
    {
        ICqActionSession apiSession;

        public ManyMiddlewares(ICqActionSession apiSession)
        {
            this.apiSession = apiSession;
        }

        public async Task WaterWaterWater(CqGroupMessagePostContext context, Func<Task> next)
        {
            string textMsg = context.Message.GetText();
            Console.WriteLine(textMsg);

            if (context.RawMessage.Contains("喵"))        // 喵喵复读机
            {
                await apiSession.SendGroupMessageAsync(context.GroupId, new CqTextMsg("喵喵喵?"));
            }
            else if (context.RawMessage.StartsWith("echo "))     // echo 复读机
            {
                await apiSession.SendGroupMessageAsync(context.GroupId, CqMsg.CqCodeChain(context.RawMessage.Substring(5)));
            }
            else if (context.RawMessage.Contains("热重载"))       // 憨批关键词
            {
                await apiSession.SendGroupMessageAsync(context.GroupId, new CqTextMsg("好耶, C# 太棒惹!"));
            }
            else if (context.RawMessage.Contains("辰辰"))        // 起哄专用
            {
                await apiSession.SendGroupMessageAsync(context.GroupId, new CqTextMsg("爆! 照~~"));
            }
            else if (context.RawMessage.Contains("亲我"))        // 自我安慰.jpg
            {
                if (context.RawMessage.Contains("悄咪咪"))
                {
                    await apiSession.SendPrivateMessageAsync(context.UserId, new CqTextMsg("mua~"));
                }
                else
                {
                    var rst = await apiSession.SendGroupMessageAsync(context.GroupId, new CqAtMessage(context.UserId), new CqTextMsg("mua~"));
                }
            }
            else if (context.RawMessage.Contains("骂我"))        // 奇怪的癖好?
            {
                if (context.RawMessage.Contains("狠狠"))
                    await apiSession.SendPrivateMessageAsync(context.UserId, new CqTextMsg("cnm"));
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

                    var rst =  await apiSession.SendGroupMessageAsync(context.GroupId, new CqTextMsg(awa[randindex]));    // 发送脏话

                    await Task.Delay(2000);                                                                       // 等待 2 秒

                    if (rst != null && rst.Status == CqActionStatus.Okay)
                    {
                        await apiSession.RecallMessageAsync(rst!.MessageId);                                             // 撤回消息
                        await apiSession.SendGroupMessageAsync(context.GroupId, new CqTextMsg("打错字惹qwq (小仙女怎么可以骂脏话呢)"));     // 发错了.jpg
                    }
                }
            }
            else if (context.RawMessage.Contains("卖个萌"))       // 怪
            {
                string[] awa = new string[]
                    {
                        "才不要呢! 哼~",
                        "略略略, 我可是有底线的, 怎么可以随便卖萌呢?",
                        "咦惹, 你这人好奇怪欸, 怎么提出这么无理的请求",
                        "(拨打110) 喂? 是警察叔叔嘛, 这里有一个奇怪的人缠着我"
                    };

                int randindex = new Random().Next(0, awa.Length);

                await apiSession.SendMessageAsync(null, context.GroupId, new CqTextMsg(awa[randindex]));
                //var rst =  await session.SendGroupMsgAsync(context.GroupId, new CqTextMsg(awa[randindex]));
            }
            else if (textMsg.Contains("假装卖萌"))
            {
                CqMsg[] fakeMsg = CqMsg.CqCodeChain("嘤嘤嘤~");
                await apiSession.SendGroupForwardMessageAsync(context.GroupId,
                    new CqForwardMessageNode(context.Sender.Nickname, context.UserId, fakeMsg, fakeMsg));
            }
            else if (textMsg.Contains("转发测试"))
            {
                await apiSession.SendGroupForwardMessageAsync(context.GroupId,
                    new CqForwardMessageNode(context.MessageId));
            }
            else if (textMsg.StartsWith("="))
            {
                await apiSession.SendGroupMessageAsync(context.GroupId, CqMsg.CqCodeChain(textMsg.Substring(1)));
            }
            else if (textMsg.Contains("禁言"))
            {
                CqAtMessage? cqMsg = context.Message.FirstOrDefault((msg) => msg is CqAtMessage) as CqAtMessage;
                if (cqMsg == null)
                    return;

                if (context.Sender.Role.HasFlag(CqRole.Admin))
                {
                    var rst = await apiSession.BanGroupMemberAsync(context.GroupId, cqMsg.QQ, TimeSpan.FromDays(10));
                }
            }

            await next();
        }
    }
}