using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqCanSendRecordActionResultDataModel : CqActionResultDataModel
    {
        public bool yes { get; }

        [JsonConstructor]
        public CqCanSendRecordActionResultDataModel(bool yes)
        {
            this.yes = yes;
        }
    }
}