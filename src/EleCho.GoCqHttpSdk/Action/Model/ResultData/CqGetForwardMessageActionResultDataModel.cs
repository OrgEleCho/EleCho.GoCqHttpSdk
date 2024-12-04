using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetForwardMessageActionResultDataModel(CqForwardMsgNodeDataModel[] messages) : CqActionResultDataModel
{
    public CqForwardMsgNodeDataModel[] messages { get; } = messages;
}