using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 上传群文件操作
/// </summary>
public class CqUploadGroupFileAction : CqAction
{
    /// <summary>
    /// 实例化 '上传群文件操作'
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    public CqUploadGroupFileAction(long groupId, string file, string name)
    {
        GroupId = groupId;
        File = file;
        Name = name;
    }

    /// <summary>
    /// 实例化 '上传群文件操作'
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="file">文件</param>
    /// <param name="name">名称</param>
    /// <param name="folder">目录</param>
    public CqUploadGroupFileAction(long groupId, string file, string name, string folder)
    {
        GroupId = groupId;
        File = file;
        Name = name;
        Folder = folder;
    }

    /// <summary>
    /// 操作类型: 上传群文件
    /// </summary>
    public override CqActionType ActionType => CqActionType.UploadGroupFile;

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; }

    /// <summary>
    /// 本地文件路径
    /// </summary>
    public string File { get; set; }

    /// <summary>
    /// 存储名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 父目录 ID
    /// </summary>
    public string? Folder { get; set; }


    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqUploadGroupFileActionParamsModel(GroupId, File, Name, Folder);
    }
}