using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 设置群昵称操作结果
/// </summary>
public record class CqSetGroupNicknameActionResult : CqActionResult
{
    internal CqSetGroupNicknameActionResult() { }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // no data
    }
}
