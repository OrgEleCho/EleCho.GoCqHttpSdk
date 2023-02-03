using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetForwardMessageActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetForwardMessageActionResultDataModel(CqForwardMsgNodeDataModel[] messages)
        {
            this.messages = messages;
        }

        public CqForwardMsgNodeDataModel[] messages { get; set; }
    }
}