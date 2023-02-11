using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 发送群消息操作结果
    /// </summary>
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