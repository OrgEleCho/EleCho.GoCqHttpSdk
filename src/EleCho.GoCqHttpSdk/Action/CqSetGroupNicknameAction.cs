using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群昵称操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
/// <param name="userId">用户 QQ</param>
/// <param name="nickname">昵称</param>
public class CqSetGroupNicknameAction(long groupId, long userId, string? nickname) : CqAction
{

    /// <summary>
    /// 操作类型: 设置群昵称
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetGroupNickname;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 用户 QQ
    /// </summary>
    public long UserId { get; set; } = userId;

    /// <summary>
    /// 昵称
    /// </summary>
    public string? Nickname { get; set; } = nickname;


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetGroupNicknameActionParamsModel(GroupId, UserId, Nickname);
    }
}
