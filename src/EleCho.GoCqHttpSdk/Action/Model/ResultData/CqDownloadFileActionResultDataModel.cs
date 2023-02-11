using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqDownloadFileActionResultDataModel : CqActionResultDataModel
    {
        public string file { get; set; } = string.Empty;

        [JsonConstructor]
        public CqDownloadFileActionResultDataModel(string file)
        {
            this.file = file;
        }
    }
}
