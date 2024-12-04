using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

internal class CqOcrImageActionResultDataModel(CqTextDetectionModel[] texts, string language) : CqActionResultDataModel
{
    public CqTextDetectionModel[] texts { get; } = texts;
    public string language { get; } = language;
}
