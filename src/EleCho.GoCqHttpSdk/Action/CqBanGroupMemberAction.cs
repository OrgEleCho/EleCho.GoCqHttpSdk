using EleCho.GoCqHttpSdk.Action.Model.Params;
using System;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 禁言群成员
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="userId">群员 QQ</param>
/// <param name="duration">时长 (如果是 0 则取消禁言)</param>
public class CqBanGroupMemberAction(long groupId, long userId, TimeSpan duration) : CqAction
{
    /// <summary>
    /// 操作类型: 禁言群成员
    /// </summary>
    public override CqActionType ActionType => CqActionType.BanGroupMember;

    /// <summary>
    /// 群 ID
    /// </summary>
    public long GroupId { get; set; } = groupId;
    /// <summary>
    /// 用户 ID
    /// </summary>
    public long UserId { get; set; } = userId;
    /// <summary>
    /// 时长
    /// </summary>
    public TimeSpan Duration { get; set; } = duration;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqBanGroupMemberActionParamsModel(GroupId, UserId, Duration.Ticks / TimeSpan.TicksPerSecond);
    }
}