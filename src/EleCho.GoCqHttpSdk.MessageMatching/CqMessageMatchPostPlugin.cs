using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    /// <summary>
    /// 消息匹配插件
    /// </summary>
    public abstract class CqMessageMatchPostPlugin
    {
        private record struct MessageMatchMethod(MethodInfo Method, CqMessageMatchAttribute Attribute, Func<CqMessagePostContext, Match, Task> Action);

        private List<MessageMatchMethod> privateMessageMatchMethods;
        private List<MessageMatchMethod> groupMessageMatchMethods;

        private void InitMethods(out List<MessageMatchMethod> privateMessageMatchMethods, out List<MessageMatchMethod> groupMessageMatchMethods)
        {
            var methods = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            privateMessageMatchMethods = new();
            groupMessageMatchMethods = new();

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
                    CqMessageType msgType = CqMessageType.Unknown;

                    // 方法参数的值获取器
                    Func<CqMessagePostContext, Match, object>[] parameterGetters = new Func<CqMessagePostContext, Match, object>[parameters.Length];

                    // 根据方法参数类型, 指定所有方法参数获取器
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        ParameterInfo parameter = parameters[i];

                        if (typeof(CqMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                        {
                            if (typeof(CqPrivateMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                            {
                                if (msgType != CqMessageType.Unknown && msgType != CqMessageType.Private)
                                    throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 定义了多个不同的 {nameof(CqMessagePostContext)}");

                                parameterGetters[i] = (context, match) => (CqPrivateMessagePostContext)context;
                                msgType = CqMessageType.Private;
                            }
                            else if (typeof(CqGroupMessagePostContext).IsAssignableFrom(parameter.ParameterType))
                            {
                                parameterGetters[i] = (context, match) => (CqGroupMessagePostContext)context;
                                msgType = CqMessageType.Group;
                            }
                            else if (typeof(CqMessagePostContext) == parameter.ParameterType)
                            {
                                parameterGetters[i] = (context, match) => context;
                            }
                            else
                            {
                                throw new InvalidOperationException($"方法 '{method.Name}' 的 '{parameter.Name}' 参数类型不正确, 它应该是 {nameof(CqMessagePostContext)}, {nameof(CqPrivateMessagePostContext)}  或 {nameof(CqGroupMessagePostContext)}");
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
                    Func<CqMessagePostContext, Match, Task> action = (context, match) =>
                    {
                        object? rst = method.Invoke(this, Array.ConvertAll(parameterGetters, getter => getter.Invoke(context, match)));
                        if (rst is Task task)
                            return task;
                        return Task.CompletedTask;
                    };

                    // 根据从参数中判断得到的应该处理的消息类型, 把方法存储添加到对应的列表中
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
            }
        }

        private CqMessagePostContext? currentContext;
        public CqMessagePostContext? CurrentContext => currentContext;

        public bool ExecuteNextWhenMatched { get; set; } = true;

        public CqMessageMatchPostPlugin()
        {
            InitMethods(out privateMessageMatchMethods, out groupMessageMatchMethods);
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

                            if (!ExecuteNextWhenMatched)
                                return;
                        }
                    }
                }
            }

            await next.Invoke();
        }
    }
}