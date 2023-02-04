using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetCookiesActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetCookiesActionResultDataModel(string cookies)
        {
            this.cookies = cookies;
        }

        public string cookies { get; set; } = string.Empty;
    }
}
