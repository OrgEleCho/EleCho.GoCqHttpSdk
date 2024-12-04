using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群根目录文件列表操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
public class CqGetGroupRootFilesAction(long groupId) : CqAction
{


    /// <summary>
    /// 操作类型: 获取群根目录文件列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupRootFiles;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupRootFilesActionParamsModel(GroupId);
    }
}