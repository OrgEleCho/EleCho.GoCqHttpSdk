# EleCho.GoCqHttpSdk

与 Go-CqHttp 通信的 SDK 本体



## 🌟实现:

- `通信`: 正向 HTTP, 反向 HTTP, 正向 WebSocket
- `消息`: (所有 Go-CqHttp 提到的消息均已实现)
- `上报`: (所有 Go-CqHttp 提到的上报均已实现, 不包含频道上报)
- `操作`: 发送私聊消息, 发送群消息, 发送群合并转发, 发送私聊合并转发消息, 发送消息, 撤回消息, 获取消息, 获取合并转发消息, 获取图片信息, 标记消息已读, 群组踢人, 群组单人禁言, 群组匿名用户禁言, 群组全员禁言, 群组设置管理员, 群组匿名, 设置群昵称, 设置群名, 退出群组, 设置群组专属头衔, 群打卡, 处理加好友请求, 处理加群请求或邀请, 获取登录号信息, 获取陌生人信息, 获取好友列表, 获取单向好友列表, 删除单向好友, 删除好友, 获取群消息, 获取群列表, 获取群成员信息, 获取群成员列表, 获取群荣誉信息, 获取 Cookies, 获取 CSRF Token, 检查是否可以发送图片, 检查是否可以发送语音, 获取版本信息, 设置群头像, 重载事件过滤器, 下载文件到缓存目录, 获取当前账号在线客户端列表, 获取群消息历史记录, 设置精华消息, 移除精华消息, 获取精华消息列表, 检查链接安全性, 获取在线机型, 设置在线机型

## 🪧命名空间:

```csharp
using EleCho.GoCqHttpSdk;            // 基础命名空间, 包含 CqSession, 拓展方法等
using EleCho.GoCqHttpSdk.Action;     // 所有 Action 声明
using EleCho.GoCqHttpSdk.Post;       // 所有上报声明
using EleCho.GoCqHttpSdk.Message;    // 所有消息声明
```

## 📚 编写规范

下面是编写时可能提供帮助的一些规范:

> 虽然库的有些内部代码真的很丑(例如命名), 但这是为了外部访问的便捷而做出的妥协, 实属无奈之举.

### 🗂️ 各个文件夹的内容

- `/Action` : 用户要使用到的各种 CqAction
- `/Action/Sender` : 用来发送 CqAction 的各个协议实现
- `/Action/Model/Params` : CqAction 进行调用时所需要的具体参数 (用户不可见)
- `/Action/Result` : 用户要使用到的各种 CqActionResult
- `/Action/Result/Model/Data` : CqActionResult 返回时要读取的具体数据 (用户不可见)
- `/DataStructure` : CqAction 参数或返回数据中所使用到的各种结构
- `/DataStructure/Model` : CqAction 参数或返回数据中所使用到的各种结构的实际传输声明 (用户不可见)
- `/Enumeration` : 各种枚举类型
- `/Extension` : 各种拓展方法
- `/JsonConverter` : 程序集所需要使用的 JSON 转换器 (用户不可见)
- `/Message` : 用户会用到的各种消息类型
- `/Message/CqCodeDef` : CQ 码操作类
- `/Message/DataModel` : 消息的实际传输数据模型 (用户不可见)
- `/Message/JsonConverter` : 某些特殊消息需要使用到的 JSON 转换器 (用户不可见)
- `/Post` : 消息上报的各种类型
- `/Utils` : 各种工具类
- `/` : 被用户直接访问, 不需要进行归类的内容

### 🛠️ 编写步骤

编写一个 Action 的参考步骤:

1. 添加 `CqActionType` 成员
2. 添加 `Consts.ActionType` 成员
3. 在 `CqEnum` 中实现 `CqActionType` 转字符串
4. 编写它的 `CqAction` 类
5. 编写它的 `CqActionParamsModel` 类 (internal, 有一个全参构造函数, 成员名称为原始名称)
6. 编写它的 `CqActionResult` 类 (不能有公开构造函数, 因为用户不能创建它的实例)
7. 编写它的 `CqActionResultDataModel` 类 (internal, 只有 JSON 构造函数, 成员名称为原始名称)
8. 实现 `CqActionResult.FromRaw`
9. 实现 `CqActionResultDataModel.FromRaw`
10. 在 `CqActionSessionExtensions` 中添加对应拓展方法

编写一个 CqMsg 的参考步骤:

1. 添加 `CqMsgType` 成员
2. 编写它的 `CqMsg` 类
3. 编写它的 `CqMsgDataModel` 类 (internal, 一个无参构造函数, 一个全参构造函数)
4. 实现它在 `CqMsgModelConverter` 中的转换
5. 实现它在 `CqCode.ModelChainFromCqCodeString` 中的转换

### 📃 命名规范

- 尽量将缩写改为全称, 尽量将奇怪的名称改为正常的名称 \
  例如: SetGroupBan -> BanGroupMember (禁言群成员)
- 尽量将错误的名称改为正确的名称 \
  例如: CheckUrlSafely -> CheckUrlSafety (检查链接安全性)

### 📎 类型声明提示

- 在原文档中以 `number` 标识的类型, 统一使用 `long`, 否则可能会溢出
- 在原文档中, 消息 ID 有的地方声明为 `int32`, 有的地方声明为 `int64`, 在本库中, 将统一使用 `int64`