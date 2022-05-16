using System;
using System.Collections.Generic;
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

        private Task EmptyFunc() => Task.CompletedTask;

        /// <summary>
        /// 使用一个中间件
        /// </summary>
        /// <param name="middleware">中间件</param>
        /// <returns>当前实例</returns>
        public CqPostPipeline Use(Func<CqPostContext, Func<Task>, Task> middleware)
        {
            middlewares.Add(middleware);
            return this;
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="context">上报上下文</param>
        /// <returns></returns>
        public Task ExecuteAsync(CqPostContext context)
        {
            return TaskExecuteAt(context, 0).Invoke();
        }

        private Func<Task> TaskExecuteAt(CqPostContext context, int index)
        {
            if (index < middlewares.Count)
            {
                return () => middlewares[index](context, TaskExecuteAt(context, index + 1));
            }

            return EmptyFunc;
        }
    }
}