using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

/// <summary>
/// 私聊消息和群聊消息的响应数据模型父类
/// </summary>
[method: JsonConstructor]    /// <summary>
                             /// 私聊消息和群聊消息的响应数据模型父类
                             /// </summary>
internal class CqSendMessageActionResultDataModel(long message_id) : CqActionResultDataModel
{
    public long message_id { get; } = message_id;
}