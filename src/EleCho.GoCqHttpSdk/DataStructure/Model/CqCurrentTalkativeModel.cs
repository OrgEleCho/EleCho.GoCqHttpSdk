using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqCurrentTalkativeModel
{
    [JsonConstructor]
    public CqCurrentTalkativeModel(long user_id, string nickname, string avatar, int day_count)
    {
        this.user_id = user_id;
        this.nickname = nickname;
        this.avatar = avatar;
        this.day_count = day_count;
    }

    public long user_id { get; set; }
    public string nickname { get; set; } = string.Empty;
    public string avatar { get; set; } = string.Empty;
    public int day_count { get; set; }
}
