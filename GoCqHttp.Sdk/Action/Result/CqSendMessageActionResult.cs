using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendMessageActionResult : CqActionResult
    {
        internal CqSendMessageActionResult() { }

        public long MessageId { get; set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqSendMessageActionResultDataModel dataModel)
            {
                MessageId = dataModel.message_id;
            }
        }
    }
}