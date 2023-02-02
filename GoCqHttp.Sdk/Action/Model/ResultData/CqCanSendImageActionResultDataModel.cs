using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqCanSendImageActionResultDataModel : CqActionResultDataModel
    {
        public bool yes { get; set; }

        [JsonConstructor]
        public CqCanSendImageActionResultDataModel(bool yes)
        {
            this.yes = yes;
        }
    }
}