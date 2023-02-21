using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;


// 实例化会话
CqWsSession session = new CqWsSession(new CqWsSessionOptions()
{
    BaseUri = new Uri("ws://localhost:4567"),
    AccessToken = "访问令牌 (如果有就填)"
});

// 好友请求处理
session.UseFriendRequest(async context =>
{
    // 同意好友请求
    await session.ApproveFriendRequestAsync(context.Flag, $"在{DateTime.Now}加的好友");


    /*
        // 拒绝好友请求
        await session.RejectFriendRequestAsync(context.Flag);

        // 同意或拒绝好友请求
        bool approve = false;    // 同意或拒绝
        await session.HandleFriendRequestAsync(context.Flag, approve, "备注信息 (如果是拒绝, 那这个字段不会产生效果)");
    */
});

// 运行
await session.RunAsync();
