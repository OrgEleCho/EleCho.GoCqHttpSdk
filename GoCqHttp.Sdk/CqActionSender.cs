using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Post.Model;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public abstract class CqActionSender
    {
        public abstract Task<CqActionResult?> InvokeActionAsync(CqAction action);
        internal abstract Task<bool> HandleQuickAction(CqPostModel context, object quickActionModel);
    }
}