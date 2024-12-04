using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Base;
using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 群成员群荣誉变更上报上下文
/// </summary>
public record class CqGroupMemberHonorChangedPostContext : CqNotifyNoticePostContext, IGroupPostContext
{
    /// <summary>
    /// 上报类型: 通知
    /// </summary>
    public override CqPostType PostType => CqPostType.Notice;

    /// <summary>
    /// 通知类型: 通知
    /// </summary>
    public override CqNoticeType NoticeType => CqNoticeType.Notify;

    /// <summary>
    /// 通知类型: 群荣誉
    /// </summary>
    public override CqNotifyType NotifyType => CqNotifyType.Honor;

    /// <summary>
    /// 群荣誉类型
    /// </summary>
    public CqHonorType HonorType { get; internal set; }

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; internal set; }

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; internal set; }

    internal CqGroupMemberHonorChangedPostContext() { }

    internal override object? QuickOperationModel => null;

    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqNoticeHonorPostModel msgModel)
            return;

        HonorType = CqEnum.GetHonorType(msgModel.honor_type);
        GroupId = msgModel.group_id;
        UserId = msgModel.user_id;
    }
}