using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 下载文件操作结果
/// </summary>
public record class CqDownloadFileActionResult : CqActionResult
{
    internal CqDownloadFileActionResult()
    {
    }

    /// <summary>
    /// 文件
    /// </summary>
    public string File { get; private set; } = string.Empty;

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqDownloadFileActionResultDataModel _m)
            throw new Exception();

        File = _m.file;
    }
}