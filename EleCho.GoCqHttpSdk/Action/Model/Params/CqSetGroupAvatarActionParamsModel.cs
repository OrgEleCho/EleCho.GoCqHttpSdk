using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupAvatarActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupAvatarActionParamsModel(long group_id, string file, int cache)
        {
            this.group_id = group_id;
            this.file = file;
            this.cache = cache;
        }

        public long group_id { get; }
        public string file { get; }

        /// <summary>
        /// boolean to integer
        /// </summary>
        public int cache { get; }
    }
}
