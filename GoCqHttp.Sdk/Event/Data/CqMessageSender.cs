namespace NullLib.GoCqHttpSdk.Event
{
    public class CqMessageSender
    {
        internal CqMessageSender(CqMessageSenderModel model)
        {
            UserId = model.user_id;
            Nickname = model.nickname;
            Sex = model.sex;
            Age = model.age;
        }
        public CqMessageSender(long userId, string nickname, string sex, int age)
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
