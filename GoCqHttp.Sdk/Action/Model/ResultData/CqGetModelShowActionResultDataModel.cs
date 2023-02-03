using System.Text.Json.Serialization;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetModelShowActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetModelShowActionResultDataModel(CqModelShowVariantModel[] variants)
        {
            this.variants = variants;
        }

        public CqModelShowVariantModel[] variants { get; set; }
    }
}