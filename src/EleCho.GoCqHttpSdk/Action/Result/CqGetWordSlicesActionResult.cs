using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 获取分词操作结果
/// </summary>
public record class CqGetWordSlicesActionResult : CqActionResult
{
    internal CqGetWordSlicesActionResult() { }

    /// <summary>
    /// 分词
    /// </summary>
    public string[] Slices { get; private set; } = [];

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqGetWordSlicesActionResultDataModel _m)
            throw new InvalidOperationException();

        Slices = _m.slices;
    }
}