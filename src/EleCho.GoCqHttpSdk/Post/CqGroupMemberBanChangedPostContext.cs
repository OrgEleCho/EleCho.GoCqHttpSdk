using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 群成员禁言状态变更上报上下文
/// </summary>
public record class CqGroupMemberBanChangedPostContext : CqNoticePostContext, IGroupPostContext
{
    /// <summary>
    /// 通知类型: 群禁言
    /// </summary>
    public override CqNoticeType NoticeType => CqNoticeType.GroupBan;

    /// <summary>
    /// 变更类型
    /// </summary>
    public CqGroupBanChangeType ChangeType { get; internal set; }

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; internal set; }

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; internal set; }

    /// <summary>
    /// 操作者 QQ
    /// </summary>
    public long OperatorId { get; internal set; }

    /// <summary>
    /// 时长 (如果为 0 则是取消禁言)
    /// </summary>
    public TimeSpan Duration { get; internal set; }

    internal CqGroupMemberBanChangedPostContext() { }

    internal override object? QuickOperationModel => null;
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqNoticeGroupBanPostModel postModel)
            return;

        ChangeType = CqEnum.GetGroupBanChangeType(postModel.sub_type);
        GroupId = postModel.group_id;
        UserId = postModel.user_id;
        OperatorId = postModel.operator_id;
        Duration = TimeSpan.FromSeconds(postModel.duration);
    }
}