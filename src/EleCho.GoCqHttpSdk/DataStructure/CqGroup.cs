using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 群信息
/// </summary>
public record class CqGroup
{
    internal CqGroup(CqGroupModel model)
    {
        GroupId = model.group_id;
        GroupName = model.group_name;
        GroupMemo = model.group_memo;
        GroupCreateTime = DateTimeOffset.FromUnixTimeSeconds(model.group_create_time).DateTime;
        GroupLevel = model.group_level;
        MemberCount = model.member_count;
        MaxMemberCount = model.max_member_count;
    }

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; }

    /// <summary>
    /// 群名
    /// </summary>
    public string GroupName { get; }

    /// <summary>
    /// 群备注
    /// </summary>
    public string GroupMemo { get; }

    /// <summary>
    /// 群创建时间
    /// </summary>
    public DateTime GroupCreateTime { get; }

    /// <summary>
    /// 群等级
    /// </summary>
    public uint GroupLevel { get; }

    /// <summary>
    /// 成员数量
    /// </summary>
    public int MemberCount { get; }

    /// <summary>
    /// 最大成员数
    /// </summary>
    public int MaxMemberCount { get; }
}
