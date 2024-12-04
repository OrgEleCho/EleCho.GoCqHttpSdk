using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSendGroupMessageActionParamsModel(long group_id, CqMsgModel[] message, bool auto_escape) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public CqMsgModel[] message { get; } = message;

    [JsonIgnore]
    public bool auto_escape { get; } = auto_escape;
}