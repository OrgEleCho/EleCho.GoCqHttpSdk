using NullLib.GoCqHttpSdk.Action.Result;
using System;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Action.Invoker
{
    public class CqHttpActionSender : CqActionSender
    {
        public override Task<CqActionResult> SendActionAsync(CqAction action)
        {
            throw new NotImplementedException();
        }
    }
}