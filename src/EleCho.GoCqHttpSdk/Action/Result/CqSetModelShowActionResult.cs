using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 设置显示机型操作结果
    /// </summary>
    public record class CqSetModelShowActionResult : CqActionResult
    {
        internal CqSetModelShowActionResult()
        {
        }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // no data
        }
    }
}