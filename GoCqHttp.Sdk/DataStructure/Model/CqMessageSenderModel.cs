using EleCho.GoCqHttpSdk;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqMessageSenderModel
    {
        public CqMessageSenderModel(CqMessageSender srcData)
        {
            user_id = srcData.UserId;
            nickname = srcData.Nickname;
            sex = CqEnum.GetString(srcData.Gender) ?? string.Empty;
            age = srcData.Age;
        }

        [JsonConstructor]
        public CqMessageSenderModel(long user_id, string nickname, string sex, int age)
        {
            this.user_id = user_id;
            this.nickname = nickname;
            this.sex = sex;
            this.age = age;
        }

        public long user_id { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
    }
}