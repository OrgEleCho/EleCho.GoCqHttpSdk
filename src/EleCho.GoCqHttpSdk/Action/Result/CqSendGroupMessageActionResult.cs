using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 发送群消息操作结果
/// </summary>
public record class CqSendGroupMessageActionResult : CqSendMessageActionResult
{
    internal CqSendGroupMessageActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        base.ReadDataModel(model);
    }
}