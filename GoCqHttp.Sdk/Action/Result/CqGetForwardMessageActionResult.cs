using EleCho.GoCqHttpSdk;
using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetForwardMessageActionResult : CqActionResult
    {
        internal CqGetForwardMessageActionResult() { }
        
        public CqForwardMessageNode[] Messages { get; private set; } = Array.Empty<CqForwardMessageNode>();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetForwardMessageActionResultDataModel dataModel)
                return;

            Messages = Array.ConvertAll(dataModel.messages ?? Array.Empty<CqForwardMsgNodeDataModel>(), (data) =>
            {
                CqForwardMessageNode node = new CqForwardMessageNode();
                node.ReadDataModel(data);
                return node;
            });
        }
    }
}