using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Post;
using EleCho.GoCqHttpSdk.Post.Model;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 用于发送 CqAction 的抽象类
    /// </summary>
    public abstract class CqActionSender
    {
        /// <summary>
        /// 发送一个 CqAction
        /// </summary>
        /// <param name="action">要发送的 Action</param>
        /// <returns>返回结果</returns>
        public abstract Task<CqActionResult?> InvokeActionAsync(CqAction action);
        internal abstract Task<bool> HandleQuickAction(CqPostContext context, CqPostModel postModel);
    }
}