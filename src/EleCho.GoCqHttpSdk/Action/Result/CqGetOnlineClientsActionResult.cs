using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取在线客户端操作结果
    /// </summary>
    public record class CqGetOnlineClientsActionResult : CqActionResult
    {
        internal CqGetOnlineClientsActionResult()
        { }
        
        /// <summary>
        /// 客户端
        /// </summary>
        public CqDevice[] Clients { get; private set; } = Array.Empty<CqDevice>();
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetOnlineClientsActionResultDataModel _m)
                throw new Exception();

            Clients = Array.ConvertAll(_m.clients, m => new CqDevice(m));
        }
    }
}