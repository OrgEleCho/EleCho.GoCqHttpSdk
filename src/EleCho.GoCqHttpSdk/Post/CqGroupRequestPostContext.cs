using EleCho.GoCqHttpSdk.Post.Interface;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 加群请求上报上下文
/// </summary>
public record class CqGroupRequestPostContext : CqRequestPostContext, IGroupPostContext
{
    /// <summary>
    /// 请求类型: 群
    /// </summary>
    public override CqRequestType RequestType => CqRequestType.Group;

    internal CqGroupRequestPostContext() { }

    /// <summary>
    /// 群请求类型
    /// </summary>
    public CqGroupRequestType GroupRequestType { get; internal set; }
    
    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; internal set; }

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; internal set; }

    /// <summary>
    /// 验证消息
    /// </summary>
    public string Comment { get; internal set; } = string.Empty;

    /// <summary>
    /// 加群标志 (用来处理加群请求)
    /// </summary>
    public string Flag { get; internal set; } = string.Empty;

    /// <summary>
    /// 快速操作
    /// </summary>
    public CqGroupRequestPostQuickOperation QuickOperation { get; }
        = new CqGroupRequestPostQuickOperation();

    internal override object? QuickOperationModel => QuickOperation.GetModel();
    internal override void ReadModel(CqPostModel model)
    {
        base.ReadModel(model);

        if (model is not CqRequestGroupPostModel requestModel)
            return;

        GroupRequestType = CqEnum.GetGroupRequestType(requestModel.sub_type);
        GroupId = requestModel.group_id;
        UserId = requestModel.user_id;
        Comment = requestModel.comment;
        Flag = requestModel.flag;
    }
}