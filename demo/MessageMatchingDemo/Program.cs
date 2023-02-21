using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.MessageMatching;


// 实例化会话
CqWsSession session = new CqWsSession(new CqWsSessionOptions()
{
    BaseUri = new Uri("ws://localhost:4567"),
    AccessToken = "访问令牌 (如果有就填)"
});

// 使用消息匹配插件
session.UseMessageMatchPlugin(
    new MyMessageMatchingPlugin(session));

// 运行
await session.RunAsync();
