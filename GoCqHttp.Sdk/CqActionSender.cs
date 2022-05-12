using NullLib.GoCqHttpSdk.Action;
using NullLib.GoCqHttpSdk.Action.Result;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public abstract class CqActionSender
    {
        public abstract Task<CqActionResult?> SendActionAsync(CqAction action);
    }
}