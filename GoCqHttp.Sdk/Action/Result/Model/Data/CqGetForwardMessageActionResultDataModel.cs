using EleCho.GoCqHttpSdk.Model;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqGetForwardMessageActionResultDataModel : CqActionResultDataModel
    {
        public CqForwardMsgNodeDataModel[] messages { get; set; }
    }
}