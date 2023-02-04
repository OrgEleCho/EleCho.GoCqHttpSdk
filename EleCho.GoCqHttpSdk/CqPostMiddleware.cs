using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public abstract class CqPostMiddleware
    {
        public abstract Task Execute(CqPostContext context, Func<Task> next);
    }
}
