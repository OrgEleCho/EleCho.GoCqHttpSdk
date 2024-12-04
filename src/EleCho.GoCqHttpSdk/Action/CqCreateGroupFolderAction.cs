using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 创建群文件文件夹操作
/// </summary>
/// <remarks>
/// 实例化
/// </remarks>
/// <param name="groupId"></param>
/// <param name="name"></param>
public class CqCreateGroupFolderAction(long groupId, string name) : CqAction
{

    /// <summary>
    /// 操作类型: 创建群文件夹
    /// </summary>
    public override CqActionType ActionType => CqActionType.CreateGroupFolder;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; } = groupId;

    /// <summary>
    /// 文件夹名称
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// 文件夹父 ID (仅能为 / )
    /// </summary>
    public string Parent { get; set; } = "/";

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqCreateGroupFolderActionParamsModel(GroupId, Name, Parent);
    }
}