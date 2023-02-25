using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetCsrfTokenActionResultDataModel : CqActionResultDataModel
    {
        public int token { get; }

        [JsonConstructor]
        public CqGetCsrfTokenActionResultDataModel(int token)
        {
            this.token = token;
        }
    }
}
