using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetOnlineClientsActionResultDataModel(CqDeviceModel[] clients) : CqActionResultDataModel
{
    public CqDeviceModel[] clients { get; } = clients;
}
