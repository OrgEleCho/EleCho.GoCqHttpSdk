using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqCheckUrlSafetyActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqCheckUrlSafetyActionResultDataModel()
        {
        }

        public int level { get; }
    }
}
