using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 获取群子目录文件列表操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
/// <param name="folderId"></param>
public class CqGetGroupFilesByFolderAction(long groupId, string folderId) : CqAction
{

    /// <summary>
    /// 操作类型: 获取群子目录文件列表
    /// </summary>
    public override CqActionType ActionType => CqActionType.GetGroupFilesByFolder;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 目录 ID
    /// </summary>
    public string FolderId { get; set; } = folderId;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqGetGroupFilesByFolderActionParamsModel(GroupId, FolderId);
    }
}