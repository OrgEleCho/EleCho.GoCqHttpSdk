using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置群匿名操作结果
    /// </summary>
    public record class CqSetGroupAnonymousActionResult : CqActionResult
    {
        internal CqSetGroupAnonymousActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // no data
        }
    }
}
