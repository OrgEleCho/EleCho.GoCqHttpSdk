using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetWordSlicesActionResultDataModel : CqActionResultDataModel
    {
        public string[] slices { get; }

        [JsonConstructor]
        public CqGetWordSlicesActionResultDataModel(string[] slices)
        {
            this.slices = slices;
        }
    }
}
