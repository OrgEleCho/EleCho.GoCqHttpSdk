using EleCho.GoCqHttpSdk.Action.Model.Data;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateForwardMessageActionResult : CqActionResult
    {
        internal CqSendPrivateForwardMessageActionResult() { }

        public long MessageId { get; set; }
        public string ForwardId { get; set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqSendPrivateForwardMessageActionResultDataModel m)
                throw new Exception();

            MessageId = m.message_id;
            ForwardId = m.forward_id;
        }
    }
}