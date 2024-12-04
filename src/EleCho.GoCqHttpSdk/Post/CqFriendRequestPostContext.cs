using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Base;
using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Post.Model.Base;
using EleCho.GoCqHttpSdk.Post.QuickOperation;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 加好友请求上报上下文
/// </summary>
public record class CqFriendRequestPostContext : CqRequestPostContext
{
    /// <summary>
    /// 请求类型: 好友
    /// </summary>
    public override CqRequestType RequestType => CqRequestType.Friend;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; internal set; }

    /// <summary>
    /// 验证消息
    /// </summary>
    public string Comment { get; internal set; } = string.Empty;

    /// <summary>
    /// 请求标志 (用来处理请求)
    /// </summary>
    public string Flag { get; internal set; } = string.Empty;
    
    internal CqFriendRequestPostContext() { }

    /// <summary>
    /// 快速操作
    /// </summary>
    public CqFriendRequestPostQuickOperation QuickOperation { get; }
        = new CqFriendRequestPostQuickOperation();

    internal override object? QuickOperationModel => QuickOperation.GetModel();
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqRequestFriendPostModel requestModel)
            return;

        UserId = requestModel.user_id;
        Comment = requestModel.comment;
        Flag = requestModel.flag;
    }
}