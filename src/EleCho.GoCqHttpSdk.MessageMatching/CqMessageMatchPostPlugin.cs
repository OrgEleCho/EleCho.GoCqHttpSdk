using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Base;

namespace EleCho.GoCqHttpSdk.MessageMatching;

/// <summary>
/// 消息匹配插件
/// </summary>
public abstract class CqMessageMatchPostPlugin
{
    private record struct MessageMatchMethod(MethodInfo Method, CqMessageMatchAttribute Attribute, Func<CqPostContext, Match, Task> Action);

    private List<MessageMatchMethod> privateMessageMatchMethods;
    private List<MessageMatchMethod> groupMessageMatchMethods;

    private List<MessageMatchMethod> privateSelfMessageMatchMethods;
    private List<MessageMatchMethod> groupSelfMessageMatchMethods;

    private void InitMethods(
        out List<MessageMatchMethod> privateMessageMatchMethods, 
        out List<MessageMatchMethod> groupMessageMatchMethods,
        out List<MessageMatchMethod> privateSelfMessageMatchMethods,
        out List<MessageMatchMethod> groupSelfMessageMatchMethods)
    {
        var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        privateMessageMatchMethods = [];
        groupMessageMatchMethods = [];
        privateSelfMessageMatchMethods = [];
        groupSelfMessageMatchMethods = [];

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes<CqMessageMatchAttribute>();
            foreach (var attribute in attributes)
            {
                var regex = attribute.Regex;
                var regexGroupNames = regex.GetGroupNames();

                var parameters = method.GetParameters();

                if (method.ReturnType != typeof(void) && !typeof(Task).IsAssignableFrom(method.ReturnType))
                    throw new InvalidOperationException($"方法 '{method.Name}' 的返回类型不正确, 必须是 void 或可等待的 {nameof(Task)}");

                // 用户需要处理的消息类型
                bool isSelfMsg = false;
                CqMessageType msgType = CqMessageType.Unknown;

                // 方法参数的值获取器
                Func<CqPostContext, Match, object>[] parameterGetters = new Func<CqPostContext, Match, object>[parameters.Length];

                // 根据方法参数类型, 指定所有方法参数获取器
                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo parameter = parameters[i];

                    if (typeof(CqMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                    {
                        if (isSelfMsg)
                            throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 同时定义了 {nameof(CqMessagePostContext)} 和 {nameof(CqSelfMessagePostContext)}");

                        if (typeof(CqPrivateMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                        {
                            if (msgType != CqMessageType.Unknown && msgType != CqMessageType.Private)
                                throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 定义了多个不同的 {nameof(CqMessagePostContext)}");

                            parameterGetters[i] = (context, match) => (CqPrivateMessagePostContext)context;
                            msgType = CqMessageType.Private;
                        }
                        else if (typeof(CqGroupMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                        {
                            if (msgType != CqMessageType.Unknown && msgType != CqMessageType.Group)
                                throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 定义了多个不同的 {nameof(CqMessagePostContext)}");

                            parameterGetters[i] = (context, match) => (CqGroupMessagePostContext)context;
                            msgType = CqMessageType.Group;
                        }
                        else if (typeof(CqMessagePostContext) == parameter.ParameterType)
                        {
                            parameterGetters[i] = (context, match) => context;
                        }
                        else
                        {
                            throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 它应该是 {nameof(CqMessagePostContext)}, {nameof(CqPrivateMessagePostContext)} 或 {nameof(CqGroupMessagePostContext)}");
                        }
                    }
                    else if (typeof(CqSelfMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                    {
                        if (!isSelfMsg && msgType != CqMessageType.Unknown)
                            throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 同时定义了 {nameof(CqMessagePostContext)} 和 {nameof(CqSelfMessagePostContext)}");

                        isSelfMsg = true;

                        if (typeof(CqPrivateSelfMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                        {
                            if (msgType != CqMessageType.Unknown && msgType != CqMessageType.Private)
                                throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 定义了多个不同的 {nameof(CqSelfMessagePostContext)}");

                            parameterGetters[i] = (context, match) => (CqPrivateSelfMessagePostContext)context;
                            msgType = CqMessageType.Private;
                        }
                        else if (typeof(CqGroupSelfMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                        {
                            if (msgType != CqMessageType.Unknown && msgType != CqMessageType.Private)
                                throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 定义了多个不同的 {nameof(CqSelfMessagePostContext)}");

                            parameterGetters[i] = (context, match) => (CqGroupSelfMessagePostContext)context;
                            msgType = CqMessageType.Group;
                        }
                        else if (typeof(CqSelfMessagePostContext) == parameter.ParameterType)
                        {
                            parameterGetters[i] = (context, match) => context;
                        }
                        else
                        {
                            throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 它应该是 {nameof(CqSelfMessagePostContext)}, {nameof(CqPrivateSelfMessagePostContext)} 或 {nameof(CqGroupSelfMessagePostContext)}");
                        }
                    }
                    else if (parameter.ParameterType == typeof(Match))
                    {
                        parameterGetters[i] = (context, match) => match;
                    }
                    else if (parameter.ParameterType == typeof(GroupCollection))
                    {
                        parameterGetters[i] = (context, match) => match.Groups;
                    }
                    else if (parameter.ParameterType == typeof(string) && parameter.Name != null)
                    {
                        if (!regexGroupNames.Contains(parameter.Name))
                            throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数名称不正确, 无法找到匹配的分组名");

                        parameterGetters[i] = (context, match) => match.Groups[parameter.Name].Value;
                    }
                    else
                    {
                        throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数不是允许的类型, 必须是 {nameof(CqMessagePostContext)} 及其子类, {nameof(Match)}, {nameof(GroupCollection)}, 或者 {nameof(String)}");
                    }
                }

                // 包装一个方法执行逻辑, 该逻辑会将所有所需参数从 context 和 match 中拿到, 并调用, 如果返回值可等待, 那么就等待
                Func<CqPostContext, Match, Task> action = (context, match) =>
                {
                    object? rst = method.Invoke(this, Array.ConvertAll(parameterGetters, getter => getter.Invoke(context, match)));
                    if (rst is Task task)
                        return task;
                    return Task.CompletedTask;
                };

                // 根据从参数中判断得到的应该处理的消息类型, 把方法存储添加到对应的列表中

                if (!isSelfMsg)
                {
                    if (msgType == CqMessageType.Private)
                    {
                        privateMessageMatchMethods.Add(new(method, attribute, action));
                    }
                    else if (msgType == CqMessageType.Group)
                    {
                        groupMessageMatchMethods.Add(new(method, attribute, action));
                    }
                    else
                    {
                        privateMessageMatchMethods.Add(new(method, attribute, action));
                        groupMessageMatchMethods.Add(new(method, attribute, action));
                    }
                }
                else
                {
                    if (msgType == CqMessageType.Private)
                    {
                        privateSelfMessageMatchMethods.Add(new(method, attribute, action));
                    }
                    else if (msgType == CqMessageType.Group)
                    {
                        groupSelfMessageMatchMethods.Add(new(method, attribute, action));
                    }
                    else
                    {
                        privateSelfMessageMatchMethods.Add(new(method, attribute, action));
                        groupSelfMessageMatchMethods.Add(new(method, attribute, action));
                    }
                }
            }
        }
    }

    private CqMessagePostContext? currentContext;

    /// <summary>
    /// 当前的消息上报上下文
    /// </summary>
    public CqMessagePostContext? CurrentContext => currentContext;

    private CqSelfMessagePostContext? currentSelfContext;

    /// <summary>
    /// 当前的我的消息上报上下文
    /// </summary>
    public CqSelfMessagePostContext? CurrentSelfContext => currentSelfContext;

    /// <summary>
    /// 当一个方法被匹配到时, 是否继续匹配下一个 (默认为 false)
    /// </summary>
    public bool MatchNextWhenMatched { get; set; } = false;

    /// <summary>
    /// 当一个方法被匹配到时, 是否继续执行下一个中间件 (默认为 true)
    /// </summary>
    public bool ExecuteNextWhenMatched { get; set; } = true;

    public CqMessageMatchPostPlugin()
    {
        InitMethods(
            out privateMessageMatchMethods, 
            out groupMessageMatchMethods,
            out privateSelfMessageMatchMethods,
            out groupSelfMessageMatchMethods);
    }

    /// <summary>
    /// 执行消息匹配方法
    /// </summary>
    /// <param name="context">上报上下文</param>
    /// <param name="next">下一个中间件</param>
    /// <returns>异步任务</returns>
    public async Task Execute(CqPostContext context, Func<Task> next)
    {
        if (context is CqMessagePostContext msgContext)
        {
            if (msgContext is CqPrivateMessagePostContext privateMsgContext)
            {
                foreach (var msgMatchMethod in privateMessageMatchMethods)
                {
                    var match = msgMatchMethod.Attribute.Regex.Match(privateMsgContext.Message.Text);
                    if (match.Success)
                    {
                        currentContext = msgContext;
                        await msgMatchMethod.Action.Invoke(privateMsgContext, match);
                        currentContext = null;

                        if (!MatchNextWhenMatched)
                            break;
                        if (!ExecuteNextWhenMatched)
                            return;
                    }
                }
            }
            else if (msgContext is CqGroupMessagePostContext groupMsgContext)
            {
                foreach (var msgMatchMethod in groupMessageMatchMethods)
                {
                    var match = msgMatchMethod.Attribute.Regex.Match(groupMsgContext.Message.Text);
                    if (match.Success)
                    {
                        currentContext = msgContext;
                        await msgMatchMethod.Action.Invoke(groupMsgContext, match);
                        currentContext = null;

                        if (!MatchNextWhenMatched)
                            break;
                        if (!ExecuteNextWhenMatched)
                            return;
                    }
                }
            }
        }
        else if (context is CqSelfMessagePostContext selfMsgContext)
        {
            if (selfMsgContext is CqPrivateSelfMessagePostContext privateMsgContext)
            {
                foreach (var msgMatchMethod in privateSelfMessageMatchMethods)
                {
                    var match = msgMatchMethod.Attribute.Regex.Match(privateMsgContext.Message.Text);
                    if (match.Success)
                    {
                        currentSelfContext = selfMsgContext;
                        await msgMatchMethod.Action.Invoke(privateMsgContext, match);
                        currentSelfContext = null;

                        if (!MatchNextWhenMatched)
                            break;
                        if (!ExecuteNextWhenMatched)
                            return;
                    }
                }
            }
            else if (selfMsgContext is CqGroupSelfMessagePostContext groupMsgContext)
            {
                foreach (var msgMatchMethod in groupSelfMessageMatchMethods)
                {
                    var match = msgMatchMethod.Attribute.Regex.Match(groupMsgContext.Message.Text);
                    if (match.Success)
                    {
                        currentSelfContext = selfMsgContext;
                        await msgMatchMethod.Action.Invoke(groupMsgContext, match);
                        currentSelfContext = null;

                        if (!MatchNextWhenMatched)
                            break;
                        if (!ExecuteNextWhenMatched)
                            return;
                    }
                }
            }
        }

        await next.Invoke();
    }
}