using EleCho.CommandLine;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.CommandExecuting
{
    public abstract class CqCommandExecutePostPlugin : CommandLineApp
    {
        /// <summary>
        /// 命令处理前缀
        /// </summary>
        public string Prefix { get; set; } = "/";

        /// <summary>
        /// 在进行回应时, 是否 at 发送者
        /// </summary>
        public bool AtInvoker { get; set; } = true;

        /// <summary>
        /// 在进行回应时, 是否回复发送者的消息
        /// </summary>
        public bool ReplyInvoker { get; set; } = false;

        /// <summary>
        /// 指令忽略大小写
        /// </summary>
        public bool IgnoreCases { get; set; } = true;

        /// <summary>
        /// 允许群聊消息
        /// </summary>
        public bool AllowGroupMessage { get; set; } = true;

        /// <summary>
        /// 允许私聊消息
        /// </summary>
        public bool AllowPrivateMessage { get; set; } = true;

        /// <summary>
        /// 允许群聊的个人消息 (当前帐号其他设备发送的消息)
        /// </summary>
        public bool AllowGroupSelfMessage { get; set; } = false;

        /// <summary>
        /// 允许私聊的个人消息 (当前账号其他设备发送的消息)
        /// </summary>
        public bool AllowPrivateSelfMessage { get; set; } = false;

        /// <summary>
        /// 当插件被执行时, 是否继续执行下一个中间件
        /// </summary>
        public bool ExecuteNextWhenExecuted { get; set; } = true;

        /// <summary>
        /// 使用并行处理
        /// </summary>
        public bool Parallel { get; set; } = false;

        private StringComparison GetStringComparison()
        {
            return IgnoreCases ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        private CqMessage BuildGroupResponse(object? result, long userId, long messageId)
        {
            CqMessage response = new CqMessage();

            if (result is CqMessage resultMsg)
            {
                response.AddRange(resultMsg);
            }
            else
            {
                response.Add($"{result}");
            }

            if (ReplyInvoker)
            {
                if (AtInvoker)
                {
                    response.WithHead(new CqAtMsg(userId));
                    response.WithHead(new CqTextMsg(" "));
                    response.WithHead(new CqReplyMsg(messageId));
                }
                else
                {
                    response.WithHead(new CqReplyMsg(messageId));
                }
            }
            else
            {
                if (AtInvoker)
                {
                    response.WithHead(new CqAtMsg(userId));
                }
            }

            return response;
        }

        private CqMessage BuildPrivateResponse(object? result, long messageId)
        {
            CqMessage response = new CqMessage();

            if (result is IEnumerable<CqMsg> resultMsgs)
            {
                response.AddRange(resultMsgs);
            }
            else
            {
                response.Add($"{result}");
            }

            if (ReplyInvoker)
                response.WithHead(new CqReplyMsg(messageId));

            return response;
        }

        private async Task ExecuteCore(CqPostContext context, Func<Task> next)
        {
            if (context is CqMessagePostContext msgContext && msgContext.Message.Text.StartsWith(Prefix))
            {
                string commandLine =
                    msgContext.Message.Text.Substring(Prefix.Length);

                try
                {
                    if (AllowGroupMessage && context is CqGroupMessagePostContext groupContext)
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (rst is Task task)
                            rst = await TaskUtils.WaitAsync(task);

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response =
                                BuildGroupResponse(rst, groupContext.UserId, groupContext.MessageId);

                            await actionSession.SendGroupMessageAsync(groupContext.GroupId, response);
                        }
                    }
                    else if (AllowPrivateMessage && context is CqPrivateMessagePostContext privateContext)
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (rst is Task task)
                            rst = await TaskUtils.WaitAsync(task);

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response =
                                BuildPrivateResponse(rst, privateContext.MessageId);

                            await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
                        }
                    }
                }
                catch (Exception exception)
                {
                    await HandleExecutingException(context, exception);
                }

                if (ExecuteNextWhenExecuted)
                    await next.Invoke();
            }
            else if (context is CqSelfMessagePostContext msgSelfContext && msgSelfContext.Message.Text.StartsWith(Prefix))
            {
                string commandLine =
                    msgSelfContext.Message.Text.Substring(Prefix.Length);

                try
                {
                    if (AllowGroupSelfMessage && context is CqGroupSelfMessagePostContext groupSelfContext)
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (rst is Task task)
                            rst = await TaskUtils.WaitAsync(task);

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response =
                                BuildGroupResponse(rst, groupSelfContext.UserId, groupSelfContext.MessageId);

                            await actionSession.SendGroupMessageAsync(groupSelfContext.GroupId, response);
                        }
                    }
                    else if (AllowPrivateSelfMessage && context is CqPrivateSelfMessagePostContext privateSelfContext)
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (rst is Task task)
                            rst = await TaskUtils.WaitAsync(task);

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response =
                                BuildPrivateResponse(rst, privateSelfContext.MessageId);

                            await actionSession.SendPrivateMessageAsync(privateSelfContext.UserId, response);
                        }
                    }
                }
                catch (Exception exception)
                {
                    await HandleExecutingException(context, exception);
                }

                if (ExecuteNextWhenExecuted)
                    await next.Invoke();
            }
            else
            {
                await next.Invoke();
            }
        }

        public async Task Execute(CqPostContext context, Func<Task> next)
        {
            Task executeTask = ExecuteCore(context, next);

            if (!Parallel)
                await executeTask;
        }

        public async Task HandleExecutingException(CqPostContext context, Exception exception)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;

            if (exception is TargetInvocationException targetInvocationException)
                exception = targetInvocationException;

            if (context is CqGroupMessagePostContext groupContext)
            {
                CqMessage response = 
                    BuildGroupResponse($"Command execution failed: {exception.Message}", groupContext.UserId, groupContext.MessageId);

                await actionSession.SendGroupMessageAsync(groupContext.GroupId, response);
            }
            else if (context is CqPrivateMessagePostContext privateContext)
            {
                CqMessage response =
                    BuildPrivateResponse($"Command execution failed: {exception.Message}", privateContext.MessageId);

                await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
            }
            else if (context is CqGroupSelfMessagePostContext groupSelfContext)
            {
                CqMessage response =
                    BuildGroupResponse($"Command execution failed: {exception.Message}", groupSelfContext.UserId, groupSelfContext.MessageId);

                await actionSession.SendGroupMessageAsync(groupSelfContext.GroupId, response);
            }
            else if (context is CqPrivateSelfMessagePostContext privateSelfMessage)
            {
                CqMessage response =
                    BuildPrivateResponse($"Command execution failed: {exception.Message}", privateSelfMessage.MessageId);

                await actionSession.SendPrivateMessageAsync(privateSelfMessage.UserId, response);
            }
        }
    }
}