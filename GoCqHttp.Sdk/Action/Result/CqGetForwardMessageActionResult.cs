using EleCho.GoCqHttpSdk.Action.Model.Data;
using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Model;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetForwardMessageActionResult : CqActionResult
    {
        internal CqGetForwardMessageActionResult() { }

        public CqForwardMessageNode[] Messages { get; set; } = null!;

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