using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 获取群文件链接操作结果
/// </summary>
public record class CqGetGroupFileUrlActionResult : CqActionResult
{
    internal CqGetGroupFileUrlActionResult() { }

    /// <summary>
    /// 文件链接
    /// </summary>
    public string Url { get; private set; } = string.Empty;

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqGetGroupFileUrlActionResultDataModel _m)
            throw new InvalidOperationException();

        Url = _m.url;
    }
}