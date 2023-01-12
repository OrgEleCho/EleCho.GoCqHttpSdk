using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
{
    internal class CqGetForwardMessageActionResultDataModel : CqActionResultDataModel
    {
        public CqForwardMsgNodeDataModel[] messages { get; set; }
    }
}