using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Model
{
    internal class CqFriendModel
    {
        public CqFriendModel(long user_id, string nickname, string remark)
        {
            this.user_id = user_id;
            this.nickname = nickname;
            this.remark = remark;
        }

        public long user_id { get; set; }
        public string nickname { get; set; }
        public string remark { get; set; }
    }
}
