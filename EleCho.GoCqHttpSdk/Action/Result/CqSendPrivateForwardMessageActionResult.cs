using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateForwardMessageActionResult : CqActionResult
    {
        internal CqSendPrivateForwardMessageActionResult() { }

        public long MessageId { get; private set; }
        public string ForwardId { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqSendPrivateForwardMessageActionResultDataModel m)
                throw new Exception();

            MessageId = m.message_id;
            ForwardId = m.forward_id;
        }
    }
}