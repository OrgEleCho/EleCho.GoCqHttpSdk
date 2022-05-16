using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Action.Result;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public abstract class CqActionSender
    {
        public abstract Task<CqActionResult?> SendActionAsync(CqAction action);
    }
}