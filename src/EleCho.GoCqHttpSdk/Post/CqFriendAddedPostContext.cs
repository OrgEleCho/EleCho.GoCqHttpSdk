
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 好友已添加上报上下文
/// </summary>
public record class CqFriendAddedPostContext : CqNoticePostContext
{
    /// <summary>
    /// 通知类型: 好友添加
    /// </summary>
    public override CqNoticeType NoticeType => CqNoticeType.FriendAdd;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; internal set; }

    internal CqFriendAddedPostContext() { }

    internal override object? QuickOperationModel => null;
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqNoticeFriendAddPostModel noticeModel)
            return;

        UserId = noticeModel.user_id;
    }
}