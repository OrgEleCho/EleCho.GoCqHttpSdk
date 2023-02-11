using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 发送消息操作结果
    /// </summary>
    public class CqSendMessageActionResult : CqActionResult
    {
        internal CqSendMessageActionResult() { }

        /// <summary>
        /// 消息 ID
        /// </summary>
        public long MessageId { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqSendMessageActionResultDataModel dataModel)
            {
                MessageId = dataModel.message_id;
            }
        }
    }
}