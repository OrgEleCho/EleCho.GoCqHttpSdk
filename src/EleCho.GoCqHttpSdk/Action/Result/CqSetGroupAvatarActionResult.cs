using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置群头像操作结果
/// </summary>
public record class CqSetGroupAvatarActionResult : CqActionResult
{
    internal CqSetGroupAvatarActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        // todo: check this
        // no data?
    }
}
