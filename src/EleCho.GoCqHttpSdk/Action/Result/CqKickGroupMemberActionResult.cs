using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 踢出群成员操作结果
    /// </summary>
    public class CqKickGroupMemberActionResult : CqActionResult
    {
        internal CqKickGroupMemberActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            // no data
        }
    }
}