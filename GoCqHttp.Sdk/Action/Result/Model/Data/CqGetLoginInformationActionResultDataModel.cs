using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
{
    internal class CqGetLoginInformationActionResultDataModel : CqActionResultDataModel
    {
        public CqGetLoginInformationActionResultDataModel(long user_id, string nickname)
        {
            this.user_id = user_id;
            this.nickname = nickname;
        }

        public long user_id { get; set; }
        public string nickname { get; set; }
    }
}
