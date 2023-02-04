using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSendGroupMessageActionResult : CqSendMessageActionResult
    {
        internal CqSendGroupMessageActionResult()
        {
        }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            base.ReadDataModel(model);
        }
    }
}