using EleCho.GoCqHttpSdk.Post;
using System;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqMessageSender
    {
        internal CqMessageSender(CqMsgSenderModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Sex = model.sex;
            Age = model.age;
        }

        public long UserId { get; set; }
        public string Nickname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}