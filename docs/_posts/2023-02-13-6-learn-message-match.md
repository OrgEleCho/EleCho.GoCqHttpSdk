---
layout: post
title:  "6. 使用拓展的消息匹配插件"
date:   2023-02-13 17:18:00 +0800
categories: tutorial
---

在 CQ HTTP 中，除了提供了最基本的消息上报，你还可以通过 EleCho.GoCqHttpSdk.MessageMatching 来获得拓展的，基于正则匹配的消息上报处理。



## 拓展方法

同样的，消息匹配拓展也提供了上报会话可用的消息匹配拓展方法，当正则匹配的时候，中间件会被执行：

```csharp
CqWsSession session;    // 要处理上报的会话

session.UseGroupMessageMatch("$echo .*", async (context, next) => {
    // 在这里处理消息上报 （这个消息一定是满足指定 pattern 的
});
```

和普通的上报拓展方法一样， 它同样也提供了不同的重载，同步中间件，包含或不包含下一个中间件参数的重载，按照你的需求选择不同的重载使用即可。



## 插件匹配

上报拓展还提供了一个可继承的插件基类，通过继承该类，并在类中写消息匹配的方法逻辑，插件则会自动调用这些方法。

```csharp
public class MyMessageMatchPlugin : CqMessageMatchPostPlugin
{
    public MyMessageMatchPlugin(ICqActionSession actionSession)
    {
        ActionSession = actionSession;
    }

    public ICqActionSession ActionSession { get; }

    // 通过 CqMessageMatch 来指定匹配规则 (例如这里非贪婪匹配两个中括号之间的任意内容, 并命名为 content 组)
    [CqMessageMatch(@"\[(?<content>.*?)\]")]
    public async Task MyMessageMatchPluginMethod(CqGroupMessagePostContext context, Match match, string content)
    {
        // 你可以在参数中指定一个合适的 CqMessagePostContext 用来接收消息上报数据
        //   它可以是 CqMessagePostContext, CqPrivateMessagePostContext, CqGroupMessagePostContext
        
        // 如果你指定了一个 Match 类型的参数, 正则匹配返回的 Match 会被传入
        // 如果你指定了字符串类型的参数, 则会自动从正则的 Groups 中取值, 并传入
    
        // 将接收到的内容所匹配到的 context 值发送到消息所在群组
        await ActionSession.SendGroupMessageAsync(context.GroupId, $"Captured content: {content}, index: {match.Index}");
        
        // 如果当前方法的返回值是一个 Task, 那么这个 Task 会被等待, 如果你不希望它被等待, 你可以指定 void 作为返回值
    }

    // 类中所有带有 CqMessageMatch 特性的方法都会被插件处理, 例如这里匹配所有消息并打印到控制台
    [CqMessageMatch(@"")]
    public void LogAllMessages()
    {
        // 即便你不在参数中指定 CqMessagePostContext, 你也可以通过插件的公开属性来获取当前上下文
        // 需要注意的是, 如果没有特意指定是群聊消息上下文或私聊消息上下文, 插件会处理任何消息

        Console.WriteLine(CurrentContext.Message.GetText());
    }
}
```

使用插件, 只需要调用 session 的拓展方法 UseMessageMatchPlugin 即可