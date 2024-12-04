using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk;

/// <summary>
/// 群文件夹
/// </summary>
public record class CqGroupFolder
{
    internal CqGroupFolder()
    { }

    internal CqGroupFolder(CqGroupFolderModel model)
    {
        GroupId = model.group_id;
        FolderId = model.folder_id;
        FolderName = model.folder_name;
        CreateTime = DateTimeOffset.FromUnixTimeSeconds(model.create_time).DateTime;
        Creator = model.creator;
        CreatorName = model.creator_name;
        TotalFileCount = model.total_file_count;
    }

    /// <summary>
    /// 群号
    /// </summary>
    public long GroupId { get; set; }

    /// <summary>
    /// 文件夹 ID
    /// </summary>
    public string FolderId { get; set; } = string.Empty;

    /// <summary>
    /// 文件夹名称
    /// </summary>
    public string FolderName { get; set; } = string.Empty;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 创建者
    /// </summary>
    public long Creator { get; set; }

    /// <summary>
    /// 创建者名称
    /// </summary>
    public string CreatorName { get; set; } = string.Empty;

    /// <summary>
    /// 文件总数
    /// </summary>
    public int TotalFileCount { get; set; }
}