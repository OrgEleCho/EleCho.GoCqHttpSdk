using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取精华消息列表操作
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="groupId">群号</param>
public class CqGetEssenceMessageListAction(long groupId) : CqAction
{
    /// <summary>
    /// 操作类型: 获取精华消息列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetEssenceMessagesList;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetEssenceMessageListActionParamsModel(GroupId);
    }
}
