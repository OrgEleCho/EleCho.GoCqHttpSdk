using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 删除群文件夹操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
/// <param name="folderId"></param>
public class CqDeleteGroupFolderAction(long groupId, string folderId) : CqAction
{

    /// <summary>
    /// 操作类型: 删除群文件夹
    /// </summary>
    public override CqActionType ActionType => CqActionType.DeleteGroupFolder;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 文件夹 ID
    /// </summary>
    public string FolderId { get; set; } = folderId;


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqDeleteGroupFolderActionParamsModel(GroupId, FolderId);
    }
}