using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 处理好友请求操作结果
    /// </summary>
    public record class CqHandleFriendRequestActionResult : CqActionResult
    {
        internal CqHandleFriendRequestActionResult() { }

        // no data

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            
        }
    }
}