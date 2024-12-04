using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Utils;
using System;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 禁言群匿名成员操作
/// </summary>
public class CqBanGroupAnonymousMemberAction : CqAction
{
    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="anonymous">匿名信息</param>
    /// <param name="duration">时长</param>
    public CqBanGroupAnonymousMemberAction(long groupId, CqAnonymousInfomation anonymous, TimeSpan duration)
    {
        GroupId = groupId;
        Anonymous = anonymous;
        Duration = duration;
    }

    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="anonymousFlag">匿名标志</param>
    /// <param name="duration">时长</param>
    public CqBanGroupAnonymousMemberAction(long groupId, string anonymousFlag, TimeSpan duration)
    {
        GroupId = groupId;
        AnonymousFlag = anonymousFlag;
        Duration = duration;
    }

    /// <summary>
    /// 操作类型: 禁言群匿名成员
    /// </summary>
    public override CqActionType ActionType => CqActionType.BanGroupAnonymousMember;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; }

    /// <summary>
    /// 匿名信息
    /// </summary>
    public CqAnonymousInfomation? Anonymous { get; set; }

    /// <summary>
    /// 匿名标志
    /// </summary>
    public string? AnonymousFlag { get; set; }

    /// <summary>
    /// 时长
    /// </summary>
    public TimeSpan Duration { get; set; }


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqBanGroupAnonymousMemberActionParamsModel(
            GroupId,
            Anonymous != null ? new CqAnonymousInformationModel(Anonymous) : null,
            AnonymousFlag,
            Duration.ToLongTotalSeconds());
    }
}
