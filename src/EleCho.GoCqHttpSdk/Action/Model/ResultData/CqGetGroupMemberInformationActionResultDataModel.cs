using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

/// <summary>
/// The same as <seealso cref="CqGroupMemberModel"/>
/// </summary>
[method: JsonConstructor]    /// <summary>
                             /// The same as <seealso cref="CqGroupMemberModel"/>
                             /// </summary>
internal class CqGetGroupMemberInformationActionResultDataModel(long group_id, long user_id, string nickname, string card, string sex, int age, string area, int join_time, int last_sent_time, string level, string role, bool unfriendly, string title, long title_expire_time, bool card_changeable, long shut_up_timestamp) : CqActionResultDataModel
{
    public long group_id { get; } = group_id;
    public long user_id { get; } = user_id;
    public string nickname { get; } = nickname;
    public string card { get; } = card;
    public string sex { get; } = sex;
    public int age { get; } = age;
    public string area { get; } = area;
    public int join_time { get; } = join_time;
    public int last_sent_time { get; } = last_sent_time;
    public string level { get; } = level;
    public string role { get; } = role;
    public bool unfriendly { get; } = unfriendly;
    public string title { get; } = title;
    public long title_expire_time { get; } = title_expire_time;
    public bool card_changeable { get; } = card_changeable;
    public long shut_up_timestamp { get; } = shut_up_timestamp;
}
