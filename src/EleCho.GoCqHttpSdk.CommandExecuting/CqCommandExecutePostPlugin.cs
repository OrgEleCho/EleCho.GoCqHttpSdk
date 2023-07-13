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
        public bool AtInvoker { get; set; } = true;
        public bool ReplyInvoker { get; set; } = false;
        public bool IgnoreCases { get; set; } = true;
        public bool AllowGroupMessage { get; set; } = true;
        public bool AllowPrivateMessage { get; set; } = true;
        public bool ExecuteNextWhenExecuted { get; set; } = true;

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

        public async Task Execute(CqPostContext context, Func<Task> next)
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
            else
            {
                await next.Invoke();
            }
        }

        public async Task HandleExecutingException(CqPostContext context, Exception exception)
        {
            if (context.Session is not ICqActionSession actionSession)
                return;

            if (exception is TargetInvocationException targetInvocationException)
                exception = targetInvocationException;

            CqMessage response = new CqMessage($"Command execution failed: {exception.Message}");
            if (context is CqGroupMessagePostContext groupContext)
            {
                if (AtInvoker)
                    response.WithHead(new CqAtMsg(groupContext.UserId));

                await actionSession.SendGroupMessageAsync(groupContext.GroupId, response);
            }
            else if (context is CqPrivateMessagePostContext privateContext)
            {
                await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
            }
        }
    }
}