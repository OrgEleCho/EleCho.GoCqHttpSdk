using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public abstract class CqActionSender
    {
        public abstract Task<CqActionResult?> InvokeActionAsync(CqAction action);
    }
}