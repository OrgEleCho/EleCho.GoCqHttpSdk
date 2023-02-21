using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.MessageMatching;
using EleCho.GoCqHttpSdk.Post;
using System.Text.RegularExpressions;

class MyMessageMatchingPlugin : CqMessageMatchPostPlugin
{
    public CqWsSession Session { get; }

    public MyMessageMatchingPlugin(CqWsSession session)
    {
        Session = session;
    }


    /// <summary>
    /// 简单的, 匹配群消息的, 用来执行 echo 指令的方法
    /// </summary>
    /// <param name="context">上报上下文</param>
    /// <param name="content">捕获组注入</param>
    [CqMessageMatch("^echo (?<content>.+)$", RegexOptions.IgnoreCase)]
    public async Task EchoAsync(CqGroupMessagePostContext context, string content)
    {
        await Session.SendGroupMessageAsync(context.GroupId, new CqMessage(content));
    }
}