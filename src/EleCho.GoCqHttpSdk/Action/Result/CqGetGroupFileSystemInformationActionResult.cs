using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// <inheritdoc/>
/// </summary>
public record class CqGetGroupFileSystemInformationActionResult : CqActionResult
{
    internal CqGetGroupFileSystemInformationActionResult()
    { }

    /// <summary>
    /// 文件总数
    /// </summary>
    public int FileCount { get; private set; }

    /// <summary>
    /// 文件上限
    /// </summary>
    public int LimitCount { get; private set; }

    /// <summary>
    /// 已使用空间
    /// </summary>
    public long UsedSpace { get; private set; }

    /// <summary>
    /// 空间总量
    /// </summary>
    public long TotalSpace { get; private set; }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqGetGroupFileSystemInformationActionResultDataModel _m)
            throw new InvalidOperationException();

        FileCount = _m.file_count;
        LimitCount = _m.limit_count;
        UsedSpace = _m.used_space;
        TotalSpace = _m.total_space;
    }
}