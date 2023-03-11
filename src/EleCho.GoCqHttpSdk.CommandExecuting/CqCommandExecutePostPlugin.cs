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
        public string Prefix { get; set; } = "/";
        public bool AtInvoker { get; set; } = true;
        public bool IgnoreCases { get; set; } = true;
        public bool AllowGroupMessage { get; set; } = true;
        public bool AllowPrivateMessage { get; set; } = true;

        private StringComparison GetStringComparison()
        {
            return IgnoreCases ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        public async Task Execute(CqPostContext context, Func<Task> next)
        {
            if (AllowGroupMessage && context is CqGroupMessagePostContext groupContext)
            {
                string commandline = groupContext.Message.Text;
                if (!commandline.StartsWith(Prefix))
                    return;

                commandline = commandline.Substring(Prefix.Length);

                try
                {
                    object? rst = 
                        Execute(commandline, GetStringComparison());

                    if (context.Session is ICqActionSession actionSession)
                    {
                        CqMessage response = new CqMessage($"{rst}");

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
                string commandline = privateContext.Message.Text;
                if (!commandline.StartsWith(Prefix))
                    return;

                commandline = commandline.Substring(Prefix.Length);

                try
                {
                    object? rst =
                        Execute(commandline, GetStringComparison());

                    if (context.Session is ICqActionSession actionSession)
                    {
                        CqMessage response = new CqMessage($"{rst}");

                        await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
                    }
                }
                catch (Exception exception)
                {
                    await HandleExecutingException(context, exception);
                }
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