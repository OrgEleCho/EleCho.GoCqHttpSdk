using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetOnlineClientsActionResult : CqActionResult
    {
        internal CqGetOnlineClientsActionResult()
        { }
        
        public CqDevice[] Clients { get; private set; } = Array.Empty<CqDevice>();
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetOnlineClientsActionResultDataModel _m)
                throw new Exception();

            Clients = Array.ConvertAll(_m.clients, m => new CqDevice(m));
        }
    }
}