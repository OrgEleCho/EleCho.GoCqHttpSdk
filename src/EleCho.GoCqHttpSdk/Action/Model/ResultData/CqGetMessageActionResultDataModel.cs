using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetMessageActionResultDataModel(bool group, long message_id, int real_id, CqMessageSenderModel sender, int time, CqMsgModel[] message, string raw_message) : CqActionResultDataModel
{
    public bool group { get; } = group;
    public long message_id { get; } = message_id;
    public int real_id { get; } = real_id;
    public CqMessageSenderModel sender { get; } = sender;
    public int time { get; } = time;
    public CqMsgModel[] message { get; } = message;
    public string raw_message { get; } = raw_message;
}