using EleCho.CommandLine;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
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
        public bool ExecuteNextWhenExecuted { get; set; } = false;

        private StringComparison GetStringComparison()
        {
            return IgnoreCases ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        public async Task Execute(CqPostContext context, Func<Task> next)
        {
            if (context is CqMessagePostContext msgContext && msgContext.Message.Text.StartsWith(Prefix))
            {
                string commandLine = 
                    msgContext.Message.Text.Substring(Prefix.Length);

                if (AllowGroupMessage && context is CqGroupMessagePostContext groupContext)
                {
                    try
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response = new CqMessage($"{rst}");

                            if (ReplyInvoker)
                                response.WithHead(new CqReplyMsg(msgContext.MessageId));
                            if (AtInvoker)
                                response.WithHead(new CqAtMsg(groupContext.UserId));

                            await actionSession.SendGroupMessageAsync(groupContext.GroupId, response);
                        }
                    }
                    catch (Exception exception)
                    {
                        await HandleExecutingException(context, exception);
                    }
                }
                else if (AllowPrivateMessage && context is CqPrivateMessagePostContext privateContext)
                {
                    try
                    {
                        object? rst =
                            Execute(commandLine, GetStringComparison());

                        if (context.Session is ICqActionSession actionSession)
                        {
                            CqMessage response = new CqMessage($"{rst}");

                            if (ReplyInvoker)
                                response.WithHead(new CqReplyMsg(msgContext.MessageId));

                            await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
                        }
                    }
                    catch (Exception exception)
                    {
                        await HandleExecutingException(context, exception);
                    }
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