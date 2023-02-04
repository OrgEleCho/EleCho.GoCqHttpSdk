using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 上报处理管道
    /// </summary>
    public class CqPostPipeline
    {
        private List<Func<CqPostContext, Func<Task>, Task>> middlewares;

        public CqPostPipeline()
        {
            middlewares = new List<Func<CqPostContext, Func<Task>, Task>>();
        }

        private Task EmptyAsyncFunc() => Task.CompletedTask;

        /// <summary>
        /// 使用一个中间件
        /// </summary>
        /// <param name="middleware">中间件</param>
        /// <returns>当前上报管线实例</returns>
        public CqPostPipeline Use(Func<CqPostContext, Func<Task>, Task> middleware)
        {
            middlewares.Add(middleware);
            return this;
        }

        /// <summary>
        /// 移除一个中间件
        /// </summary>
        /// <param name="middleware">中间件</param>
        /// <returns>当前上报管线实例</returns>
        public CqPostPipeline Remove(Func<CqPostContext, Func<Task>, Task> middleware)
        {
            middlewares.Remove(middleware);
            return this;
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="context">上报上下文</param>
        /// <returns></returns>
        public Task ExecuteAsync(CqPostContext context)
        {
            return ExecuteAsync(context, CancellationToken.None);
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="context">上报上下文</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public Task ExecuteAsync(CqPostContext context, CancellationToken cancellationToken)
        {
            return TaskExecuteAt(context, 0, cancellationToken).Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="index"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private Func<Task> TaskExecuteAt(CqPostContext context, int index, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return EmptyAsyncFunc;

            if (index < middlewares.Count)
            {
                return () => middlewares[index](context, TaskExecuteAt(context, index + 1, cancellationToken));
            }

            return EmptyAsyncFunc;
        }
    }
}