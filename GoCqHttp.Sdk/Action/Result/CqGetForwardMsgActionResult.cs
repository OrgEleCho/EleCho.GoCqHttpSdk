using EleCho.GoCqHttpSdk.Action.Result.Model.Data;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.DataStructure.Model;
using System;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public class CqGetForwardMsgActionResult : CqActionResult
    {
        public CqForwardMsgNode[] Messages { get; set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetForwardMsgActionResultDataModel dataModel)
                return;

            Messages = Array.ConvertAll(dataModel.messages ?? Array.Empty<CqForwardMsgNodeDataModel>(), (data) =>
            {
                CqForwardMsgNode node = new CqForwardMsgNode();
                node.ReadDataModel(data);
                return node;
            });
        }
    }
}