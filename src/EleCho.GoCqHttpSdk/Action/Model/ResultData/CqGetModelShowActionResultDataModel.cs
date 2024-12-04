using System.Text.Json.Serialization;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetModelShowActionResultDataModel(CqModelShowVariantModel[] variants) : CqActionResultDataModel
{
    public CqModelShowVariantModel[] variants { get; } = variants;
}