using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// <inheritdoc/>
/// </summary>
public record class CqCheckUrlSafetyActionResult : CqActionResult
{
    internal CqCheckUrlSafetyActionResult()
    {
    }


    /// <summary>
    /// 安全等级
    /// </summary>
    public CqUrlSafetyLevel Level { get; private set; }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqCheckUrlSafetyActionResultDataModel _m)
            throw new Exception();

        Level = (CqUrlSafetyLevel)_m.level;
    }
}