using EleCho.GoCqHttpSdk.Action.Result.Model.Data;

namespace EleCho.GoCqHttpSdk.Action.Result
{
    public class CqSendPrivateMessageActionResult : CqSendMessageActionResult
    {
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            base.ReadDataModel(model);
        }
    }
}