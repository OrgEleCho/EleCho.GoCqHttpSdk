using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.DataStructure
{
    public class CqMsgSender
    {
        internal CqMsgSender(CqMsgSenderModel model)
        {
            if (model == null)
                return;
            
            UserId = model.user_id;
            Nickname = model.nickname;
            Sex = model.sex;
            Age = model.age;
        }

        public CqMsgSender(long userId, string nickname, string sex, int age)
        {
            UserId = userId;
            Nickname = nickname;
            Sex = sex;
            Age = age;
        }

        public long UserId { get; set; }
        public string Nickname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}