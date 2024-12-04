using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群文件系统信息操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
public class CqGetGroupFileSystemInformationAction(long groupId) : CqAction
{

    /// <summary>
    /// 操作类型: 获取群文件系统信息
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupFileSystemInformation;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupFileSystemInformationActionParamsModel(GroupId);
    }
}