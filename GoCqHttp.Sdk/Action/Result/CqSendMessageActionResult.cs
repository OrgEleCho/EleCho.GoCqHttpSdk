using EleCho.GoCqHttpSdk.Action.Result.Model.Data;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public class CqSendMessageActionResult : CqActionResult
    {
        public int MessageId { get; set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqSendMessageActionResultDataModel dataModel)
            {
                MessageId = dataModel.message_id;
            }
        }
    }
}