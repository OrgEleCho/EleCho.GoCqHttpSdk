using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk
{
    /// <summary>
    /// 好友信息
    /// </summary>
    public record class CqFriend
    {
        internal CqFriend(CqFriendModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Remark = model.remark;
        }

        public long UserId { get; }
        public string Nickname { get; }
        public string Remark { get; }
    }
}
