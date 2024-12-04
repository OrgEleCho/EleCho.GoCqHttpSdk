using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqGroupHonorOwnerModel
{
    [JsonConstructor]
    public CqGroupHonorOwnerModel(long user_id, string nickname, string avatar, string description)
    {
        this.user_id = user_id;
        this.nickname = nickname;
        this.avatar = avatar;
        this.description = description;
    }

    public long user_id { get; }
    public string nickname { get; } = string.Empty;
    public string avatar { get; } = string.Empty;
    public string description { get; } = string.Empty;
}
