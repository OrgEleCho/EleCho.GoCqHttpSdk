using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateMessageActionResult : CqSendMessageActionResult
    {
        internal CqSendPrivateMessageActionResult()
        {
        }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            base.ReadDataModel(model);
        }
    }
}