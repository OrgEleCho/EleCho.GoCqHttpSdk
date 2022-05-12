# GoCqHttpSdk

欸嘿, 是一个 go-cqhttp 的 .NET SDK \~ (但是目前仍在开发中qwq)

## 支持:

正向 WebSocket, 正向 HTTP. (不过仅支持 array 格式的数据上报, 不支持 cqcode 解析 (懒了懒了, cqcode 解析起来一定很麻烦吧qaq))

> 正向 HTTP 尚且在开发中 (咕咕咕...)

## 使用:

#### 配置:

因为 SDK 仅支持 array 格式的数据上报, 所以请设定 go-cqhttp 配置文件中 message.post-format 字段值为 array, 否则无法正常接收上报数据

```yaml
# 这是你的 go-cqhttp 的 config.yaml 文件中应该调整的配置项
message:
  post-format: array
```

#### 连接

要与 go-cqhttp 建立一个 WebSocket 连接, 需要使用位于 `NullLib.GoCqHttpSdk` 命名空间下的 `CqWsSession` 来创建一个会话

```csharp
// 初始化一个 CqWsSession 用来与 go-cqhttp
CqWsSession session = new CqWsSession(new CqWsSessionOptions()
{
    BaseUri = new Uri("ws://127.0.0.1:6700"),  // WebSocket 地址
    UseApiEndPoint = true,                     // 使用 api 终结点
    UseEventEndPoint = true,                   // 使用事件终结点
});
```

> 指定 *UseApiEndPoint* 和 *UseEventEndPoint* 将使用独立的 api 和 event 套接字来单独处理功能调用以及事件处理
> 参考文档: [Onebot11:正向WebSocket](https://github.com/botuniverse/onebot-11/blob/master/communication/ws.md)

#### 上报

上报数据也就是所谓的 "事件", 所有继承了 `NullLib.GoCqHttpSdk.ICqPostSession` 接口的类都将处理上报数据, 该接口规定必须要有一个名为 *PostPipeline* 的 `CqPostPipeline` 成员

`CqPostPipeline` 是用户处理上报的途径, 它符合中间件设计模型, 你可以直接使用使用它添加中间件.

```csharp
CqWsSession session;   // 要处理上报数据的会话
session.PostPipeline.Use(async (context, next) =>
{
    // context 为上报数据的上下文, 其中包含了具体的信息
    
    // 在这里添加你的逻辑代码 //
    
    // next 是中间件管道中的下一个中间件, 
    // 如果你希望当中间件执行时, 不继续执行下一个中间件
    // 可以选择不执行 next
    await next();
});
```

上述订阅方法将会处理所有的上报, 我们更推荐使用 `NullLib.GoCqHttpSdk.CqActionContextExtensions` 类所提供的拓展方法, 通过它你可以非常便捷的处理任何具体类型的事件

```csharp
CqWsSession session;   // 要处理上报数据的会话
session.PostPipeline.UseGroupMsg(async (context, next) =>
{
    // context 为 CqGroupMessagePostContext, 其中包含了群聊消息的具体信息
    
    // 在这里添加你的逻辑代码 //
    
    // 简单实现一个复读机:
    if (context.RawMessage.StartsWith("echo "))
    {
        string msg = context.RawMessage.SubString(5);                  // 获取 "echo " 后的字符
        context.SendGroupMsgAsync(context.GroupId, new CqTextMsg(msg)); // 发送它 (关于消息发送后面会详细讲解)
    }
    
    await next();
});
```

#### 消息发送

所有继承了 `NullLib.GoCqHttpSdk.ICqActionSession` 接口的类都将具备使用 "Action" 的能力, 消息发送属于 "Action", 该接口规定必须有一个名为 *ActionSender* 的 `CqActionSender` 成员

`CqActionSender` 是程序向 go-cqhttp 发送 "Action" 的途径, 其中需要实现 `CqAction` 的发送逻辑以及响应逻辑, 你可以直接使用它来调用任何 `CqAction`

```csharp
CqWsSession session;   // 要使用 Action 的会话
session.ActionSender.SendActionAsync(new CqSendGroupMsgAction(群聊ID, new CqMsg[] { new CqTextMsg("一个文本消息") }));
```

可以看到, 使用 *session.ActionSender* 直接发送 `Action` 的步骤比较繁琐, 所以同样的, 推荐使用拓展方法, 它们由 `NullLib.GoCqHttpSdk.CqActionSessionExtensions` 提供.

```csharp
CqWsSession session;   // 要使用 Action 的会话
context.SendGroupMsgAsync(群聊ID, new CqTextMsg("一个文本消息")); // 发送它 (关于消息发送后面会详细讲解)
```

> `NullLib.GoCqHttpSdk.CqActionSessionExtensions` 类不直接为 `CqActionSender` 类提供拓展, 你只能在实现了 `ICqActionSession` 接口的类上调用这些拓展方法

## 项目

### 关于数据结构

因为 go-cqhttp 给的数据, json 都是小驼峰, 并且为了用户操作上的便捷, 所以 JSON 解析上使用了以下方法:

1. 分为用户的操作类和具体调用时使用的 Model 类
2. 在调用接口, 或者解析上报的时候, 两种类会相互转换
3. 一些原始 Model 类中的 `data` 字段, 或者 `params` 字段, 他们在用户的操作类中直接作为类型成员存在, 而不独立分出一个 `data` 或 `params` 成员存放.

同时, 为了用户操作的便捷, 用户所操作的类与实际传输使用的类, 字段格式是不一样的, 例如在 Music 消息中 sub_type 表示该 Music 消息的音乐类型, 于是在用户的操作类中, 它使用 MusicType 命名.

#### 消息

首先是 `go-cqhttp` 中的基础消息类型, 也就是 CQ 码(CQ Code):

它的 JSON 格式是这样的:

```json
{
    "type": "消息类型",
    "data": {
        // 消息的数据
    }
}
```

如果让用户操作 data, 肯定有些繁琐, 所以在用户操作的类中, 是这样的:
```csharp
public class CqXxxMsg : CqMsg
{
    public override string Type => "消息类型";  // Type 是不允许用户修改的, 一个类型对应一个 Type
    
    // 直接将消息数据作为消息的成员
}
```

#### 上报

上报的原始数据 JSON 格式中, 并没有专门为数据抽出一个 data 字段, 所以不做特殊处理.

#### Action

Action 在 go-cqhttp 中的 JSON 格式与消息类似, 它为参数抽出了一个 params 字段, 然后将所有参数放在这个字段中. 所以在这方面, 做了与消息类型近似的处理, 也就是直接将参数独立出来, 而不是放在 params 字段中.

同样, ActionResult(Action 调用的返回结果) 也将数据放在了 data 字段中, 所以同样做了特殊处理.

## 贡献

关于任何对项目上的不满, 例如命名, 设计模式, 或者其他任何方面的问题, 直接提交一个 discussion 就可以啦, 然后咱们就可以讨论讨论具体要采取什么措施啦. ψ(｀∇´)ψ




