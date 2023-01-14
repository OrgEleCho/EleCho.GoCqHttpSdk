using EleCho.GoCqHttpSdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    public class CqFriend
    {
        internal CqFriend(CqFriendModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Remark = model.remark;
        }

        public long UserId { get; set; }
        public string Nickname { get; set; }
        public string Remark { get; set; }
    }
}
