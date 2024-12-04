using EleCho.CommandLine;
using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.CommandExecuting;

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

    /// <summary>
    /// 裁剪消息首部的空白符
    /// </summary>
    public bool TrimStart { get; set; } = false;

    /// <summary>
    /// 裁剪消息尾部的空白符
    /// </summary>
    public bool TrimEnd { get; set; } = false;


    AsyncLocal<CqMessagePostContext?> _asyncLocalCurrentContext = new();
    AsyncLocal<CqSelfMessagePostContext?> _asyncLocalCurrentSelfContext = new();

    /// <summary>
    /// 获取当前是否有可用的 <see cref="CqMessagePostContext"/>
    /// </summary>
    public bool HasContext => _asyncLocalCurrentContext.Value != null;

    /// <summary>
    /// 获取当前是否有可用的 <see cref="CqSelfMessagePostContext"/>
    /// </summary>
    public bool HasSelfContext => _asyncLocalCurrentSelfContext.Value != null;

    public CqMessagePostContext CurrentContext => _asyncLocalCurrentContext.Value ?? 
        throw new InvalidOperationException($"该值只能在命令被触发且消息为他人消息时获取 (要判断是否能获取, 请使用 {nameof(HasContext)})");
    public CqSelfMessagePostContext CurrentSelfContext => _asyncLocalCurrentSelfContext.Value ??
        throw new InvalidOperationException($"该值只能在命令被触发且消息为自己的消息时获取 (要判断是否能获取, 请使用 {nameof(HasSelfContext)})");


    private StringComparison GetStringComparison()
    {
        return IgnoreCases ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
    }

    private CqMessage BuildGroupResponse(object? result, long userId, long messageId)
    {
        CqMessage response = [];

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
        CqMessage response = [];

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
        if (context is CqMessagePostContext msgContext && msgContext.Message.Text is string messageText)
        {
            if (TrimStart)
                messageText = messageText.TrimStart();
            if (TrimEnd)
                messageText = messageText.TrimEnd();

            if (!messageText.StartsWith(Prefix))
                goto MethodEnd;

            _asyncLocalCurrentContext.Value = msgContext;

            string commandLine =
                messageText.Substring(Prefix.Length);

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
        else if (context is CqSelfMessagePostContext msgSelfContext && msgSelfContext.Message.Text is string selfMessageText)
        {
            if (TrimStart)
                selfMessageText = selfMessageText.TrimStart();
            if (TrimEnd)
                selfMessageText = selfMessageText.TrimEnd();

            if (!selfMessageText.StartsWith(Prefix))
                goto MethodEnd;

            _asyncLocalCurrentSelfContext.Value = msgSelfContext;

            string commandLine =
                selfMessageText.Substring(Prefix.Length);

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

        MethodEnd:
        _asyncLocalCurrentContext.Value = null;
        _asyncLocalCurrentSelfContext.Value = null;
    }

    public async Task Execute(CqPostContext context, Func<Task> next)
    {
        Task executeTask = ExecuteCore(context, next);

        if (!Parallel)
            await executeTask;
    }

    /// <summary>
    /// 从执行异常生成错误消息
    /// </summary>
    /// <param name="exception">异常对象</param>
    /// <returns>错误消息</returns>
    public virtual string GenerateErrorMessageFromExcutingException(Exception exception)
    {
        if (exception is TargetInvocationException targetInvocationException && 
            targetInvocationException.InnerException is Exception innerException)
            exception = innerException;

        return $"Command execution failed: {exception.Message}";
    }

    /// <summary>
    /// 处理执行异常
    /// </summary>
    /// <param name="context">上报上下文</param>
    /// <param name="exception">异常对象</param>
    /// <returns>供等待的任务</returns>
    public virtual async Task HandleExecutingException(CqPostContext context, Exception exception)
    {
        if (context.Session is not ICqActionSession actionSession)
            return;

        if (context is CqGroupMessagePostContext groupContext)
        {
            CqMessage response = 
                BuildGroupResponse(GenerateErrorMessageFromExcutingException(exception), groupContext.UserId, groupContext.MessageId);

            await actionSession.SendGroupMessageAsync(groupContext.GroupId, response);
        }
        else if (context is CqPrivateMessagePostContext privateContext)
        {
            CqMessage response =
                BuildPrivateResponse(GenerateErrorMessageFromExcutingException(exception), privateContext.MessageId);

            await actionSession.SendPrivateMessageAsync(privateContext.UserId, response);
        }
        else if (context is CqGroupSelfMessagePostContext groupSelfContext)
        {
            CqMessage response =
                BuildGroupResponse(GenerateErrorMessageFromExcutingException(exception), groupSelfContext.UserId, groupSelfContext.MessageId);

            await actionSession.SendGroupMessageAsync(groupSelfContext.GroupId, response);
        }
        else if (context is CqPrivateSelfMessagePostContext privateSelfMessage)
        {
            CqMessage response =
                BuildPrivateResponse(GenerateErrorMessageFromExcutingException(exception), privateSelfMessage.MessageId);

            await actionSession.SendPrivateMessageAsync(privateSelfMessage.UserId, response);
        }
    }
}