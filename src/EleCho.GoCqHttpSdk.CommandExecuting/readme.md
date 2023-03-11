# EleCho.GoCqHttpSdk.CommandExecuting

EleCho.GoCqHttpSdk 的命令执行拓展

## 功能:

提供简便易用的命令行执行拓展插件

## 使用:

定义自己的命令执行插件:

```csharp
class MyCommandExecutePlugin : CqCommandExecutePostPlugin
{
    [Command]
    public int Add(int a, int b)
    {
        return a + b;
    }
}
```

> 使用插件, 只需要调用 UseCommandExecutePlugin 拓展方法即可

在使用以上插件后, 在群聊消息中发送 `/add 1 2` 即可得到机器人的回复 `3`

> 注意, 功能依赖于 `EleCho.CommandLine` 库, 如果你需要使用最新的指令功能, 你需要直接引用该库的最新版本. (包默认会引用 1.0.2 版本)

---

> ~~EleCho.GoCqHttpSdk 提供了甚至令人难以坐和放宽的拓展功能，从此再也不需要使用令人难以琢磨的标记，按下功率，享受轻松光亮的拓展背包吧~~