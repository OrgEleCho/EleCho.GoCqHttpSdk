# EleCho.GoCqHttpSdk.MessageMatching

EleCho.GoCqHttpSdk 的消息匹配拓展

## 功能:

提供基于正则匹配的消息上报处理拓展以及插件基类

## 使用:

包提供了拓展的中间件处理拓展, 你可以这样使用:

```csharp
CqWsSession session;   // 需要添加处理中间件的会话

// 匹配开头是 `echo` 和空格的消息
session.UseGroupMessageMatch("$echo ", async (context, next) =>
{
    // 发送复读消息
    await session.SendGroupMessage(context.GroupId, context.Message.GetText()[5..];
});
```

包提供了插件基类, 你可以这样使用:

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

> 使用插件, 只需要调用 UseMessageMatchPlugin 拓展方法即可