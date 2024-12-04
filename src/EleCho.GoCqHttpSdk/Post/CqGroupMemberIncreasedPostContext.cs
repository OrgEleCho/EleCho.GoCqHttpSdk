using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Base;
using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 群成员增加上报上下文
/// </summary>
public record class CqGroupMemberIncreasedPostContext : CqNoticePostContext, IGroupPostContext
{
    /// <summary>
    /// 通知类型: 群成员增加
    /// </summary>
    public override CqNoticeType NoticeType => CqNoticeType.GroupIncrease;

    /// <summary>
    /// 变更类型
    /// </summary>
    public CqGroupIncreaseChangeType ChangeType { get; internal set; }

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

    internal CqGroupMemberIncreasedPostContext() { }

    internal override object? QuickOperationModel => null;
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqNoticeGroupIncreasePostModel postModel)
            return;

        ChangeType = CqEnum.GetGroupIncreaseChangeType(postModel.sub_type);
        GroupId = postModel.group_id;
        UserId = postModel.user_id;
        OperatorId = postModel.operator_id;
    }
}