using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetLoginInformationActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetLoginInformationActionResultDataModel(long user_id, string nickname)
        {
            this.user_id = user_id;
            this.nickname = nickname;
        }

        public long user_id { get; set; }
        public string nickname { get; set; }
    }
}
