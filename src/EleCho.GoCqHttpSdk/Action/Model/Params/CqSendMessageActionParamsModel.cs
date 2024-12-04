using EleCho.GoCqHttpSdk.Message.DataModel;
using System;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSendMessageActionParamsModel(string? message_type, long? user_id, long? group_id, CqMsgModel[] message) : CqActionParamsModel
{
    public string? message_type { get; } = message_type;
    public long? user_id { get; } = user_id;
    public long? group_id { get; } = group_id;
    public CqMsgModel[] message { get; } = message;

    [JsonIgnore]
    [Obsolete("传输协议使用 JSON, 所以该属性无用")]
    public bool auto_escape { get; }
}