using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;


// 实例化会话
CqWsSession session = new CqWsSession(new CqWsSessionOptions()
{
    BaseUri = new Uri("ws://localhost:4567"),
    AccessToken = "访问令牌 (如果有就填)"
});

// 群消息处理
session.UseGroupMessage(async context =>
{
    string msgText = context.Message.Text;
    if (msgText.StartsWith("ECHO ", StringComparison.OrdinalIgnoreCase))
    {
        await session.SendGroupMessageAsync(context.GroupId, new CqMessage(msgText[5..]));
    }
});

// 运行
await session.RunAsync();
