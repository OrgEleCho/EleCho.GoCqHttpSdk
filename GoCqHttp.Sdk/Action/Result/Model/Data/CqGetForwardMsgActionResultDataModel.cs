using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
{
    internal class CqGetForwardMsgActionResultDataModel : CqActionResultDataModel
    {
        public CqForwardMsgNodeDataModel[] messages { get; set; }
    }
}