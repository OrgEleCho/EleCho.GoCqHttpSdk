using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetOnlineClientsActionResultDataModel : CqActionResultDataModel
    {
        public CqDeviceModel[] clients { get; }

        [JsonConstructor]
        public CqGetOnlineClientsActionResultDataModel(CqDeviceModel[] clients)
        {
            this.clients = clients;
        }
    }
}
