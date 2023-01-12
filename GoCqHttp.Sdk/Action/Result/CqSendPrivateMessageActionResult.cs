using EleCho.GoCqHttpSdk.Action.Model.Data;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendPrivateMessageActionResult : CqSendMessageActionResult
    {
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            base.ReadDataModel(model);
        }
    }
}