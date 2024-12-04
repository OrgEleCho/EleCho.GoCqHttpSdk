using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

/// <summary>
/// The same as <seealso cref="CqGroupModel"/>
/// </summary>
[method: JsonConstructor]    /// <summary>
                             /// The same as <seealso cref="CqGroupModel"/>
                             /// </summary>
internal class CqGetGroupInformationActionResultDataModel(long group_id, string group_name, string group_memo, uint group_create_time, uint group_level, int member_count, int max_member_count) : CqActionResultDataModel
{
    public long group_id { get; } = group_id;
    public string group_name { get; } = group_name;
    public string group_memo { get; } = group_memo;
    public uint group_create_time { get; } = group_create_time;
    public uint group_level { get; } = group_level;
    public int member_count { get; } = member_count;
    public int max_member_count { get; } = max_member_count;
}
