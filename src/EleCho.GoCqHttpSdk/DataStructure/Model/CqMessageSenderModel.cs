using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqMessageSenderModel
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

    public long user_id { get; }
    public string nickname { get; }
    public string sex { get; }
    public int age { get; }
}