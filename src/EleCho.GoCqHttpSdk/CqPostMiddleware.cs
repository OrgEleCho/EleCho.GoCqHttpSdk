using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 上报中间件
    /// </summary>
    public abstract class CqPostMiddleware
    {
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public abstract Task Execute(CqPostContext context, Func<Task> next);
    }
}
