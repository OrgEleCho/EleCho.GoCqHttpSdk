using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action.Result;

/// <summary>
/// 发送私聊消息操作结果
/// </summary>
public record class CqSendPrivateMessageActionResult : CqSendMessageActionResult
{
    internal CqSendPrivateMessageActionResult()
    {
    }

    internal override void ReadDataModel(CqActionResultDataModel? model)
    {
        base.ReadDataModel(model);
    }
}