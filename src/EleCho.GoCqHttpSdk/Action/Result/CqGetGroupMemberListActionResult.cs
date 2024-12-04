using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using EleCho.GoCqHttpSdk.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 获取群成员列表操作结果
/// </summary>
public record class CqGetGroupMemberListActionResult : CqActionResult
{
    internal CqGetGroupMemberListActionResult() { }

    /// <summary>
    /// 成员
    /// </summary>
    public IReadOnlyList<CqGroupMember> Members { get; private set; } = new List<CqGroupMember>(0).AsReadOnly();

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        if (model is not CqGetGroupMemberListActionResultDataModel m)
            throw new ArgumentException();

        Members = m.Select(fm => new CqGroupMember(fm)).ToList().AsReadOnly();
    }
}
