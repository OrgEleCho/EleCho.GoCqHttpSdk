using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    public abstract class CqMessageMatchPostPlugin
    {
        private record struct MessageMatchMethod(MethodInfo Method, CqMessageMatchAttribute Attribute, Func<CqMessagePostContext, Match, Task> Action);

        private List<MessageMatchMethod>? privateMessageMatchMethods;
        private List<MessageMatchMethod>? groupMessageMatchMethods;

        private void ScanMethods(out List<MessageMatchMethod> privateMessageMatchMethods, out List<MessageMatchMethod> groupMessageMatchMethods)
        {
            this.GetType();
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

                    if (parameters.Length < 1)
                        throw new ArgumentException("参数数量不正确");
                    if (!typeof(CqMessagePostContext).IsAssignableFrom(parameters[0].ParameterType))
                        throw new ArgumentException("参数类型不正确, 第一个参数必须是 CqMessagePostContext 的子类, 它用于判断方法截取群消息还是私聊消息, 以及接收消息上报相关数据");
                    if (parameters[1].ParameterType != typeof(Match))
                        throw new ArgumentException("参数类型不正确");
                    if (method.ReturnType != typeof(void) && !typeof(Task).IsAssignableFrom(method.ReturnType))
                        throw new ArgumentException("返回类型不正确, 必须是 void 或可等待的 Task");

                    Func<CqMessagePostContext, Match, object>[] parameterGetters = new Func<CqMessagePostContext, Match, object>[parameters.Length];

                    for (int i = 1; i < parameters.Length; i++)
                    {
                        ParameterInfo parameter = parameters[i];
                        if (parameter.ParameterType == typeof(Match))
                        {
                            parameterGetters[i] = (context, match) => match;
                        }
                        else if (parameter.ParameterType == typeof(GroupCollection))
                        {
                            parameterGetters[i] = (context, match) => match.Groups;
                        }
                        else if (parameter.ParameterType == typeof(string))
                        {
                            if (!regexGroupNames.Contains(parameter.Name))
                                throw new ArgumentException("方法参数名不正确, 无法找到匹配的分组名");

                            parameterGetters[i] = (context, match) => match.Groups[parameter.Name].Value;
                        }
                    }

                    Func<CqMessagePostContext, Match, Task> action = (context, match) =>
                    {
                        object rst = method.Invoke(this, Array.ConvertAll(parameterGetters, getter => getter.Invoke(context, match)));
                        if (rst is Task task)
                            return task;
                        return Task.CompletedTask;
                    };

                    if (typeof(CqPrivateMessagePostContext).IsAssignableFrom(parameters[0].ParameterType))
                    {
                        parameterGetters[0] = (context, match) => (CqPrivateMessagePostContext)context;
                        privateMessageMatchMethods.Add(new(method, attribute, action));
                    }
                    else if (typeof(CqGroupMessagePostContext).IsAssignableFrom(parameters[0].ParameterType))
                    {
                        parameterGetters[0] = (context, match) => (CqGroupMessagePostContext)context;
                        groupMessageMatchMethods.Add(new(method, attribute, action));
                    }
                }
            }
        }

        public async Task Execute(CqPostContext context, Func<Task> next)
        {
            if (privateMessageMatchMethods == null || groupMessageMatchMethods == null)
                ScanMethods(out privateMessageMatchMethods, out groupMessageMatchMethods);

            if (context is CqMessagePostContext msgContext)
            {
                if (msgContext is CqPrivateMessagePostContext privateMsgContext)
                {
                    foreach (var msgMatchMethod in privateMessageMatchMethods)
                    {
                        var match = msgMatchMethod.Attribute.Regex.Match(privateMsgContext.Message.GetText());
                        if (match.Success)
                        {
                            await msgMatchMethod.Action.Invoke(privateMsgContext, match);
                            return;
                        }
                    }
                }
                else if (msgContext is CqGroupMessagePostContext groupMsgContext)
                {
                    foreach (var msgMatchMethod in groupMessageMatchMethods)
                    {
                        var match = msgMatchMethod.Attribute.Regex.Match(groupMsgContext.Message.GetText());
                        if (match.Success)
                        {
                            await msgMatchMethod.Action.Invoke(groupMsgContext, match);
                            return;
                        }
                    }
                }
            }
            else
            {
                await next.Invoke();
            }
        }
    }
}