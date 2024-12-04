using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 获取 Cookies 操作结果
/// </summary>
public record class CqGetCookiesActionResult : CqActionResult
{
    internal CqGetCookiesActionResult()
    {
    }

    /// <summary>
    /// Cookies 值
    /// </summary>
    public string Cookies { get; private set; } = string.Empty;

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqGetCookiesActionResultDataModel _m)
            throw new Exception();

        Cookies = _m.cookies;
    }
}
