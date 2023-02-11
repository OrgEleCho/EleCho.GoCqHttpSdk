using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群列表操作
    /// </summary>
    public class CqGetGroupListAction : CqAction
    {
        /// <summary>
        /// 操作类型: 获取群列表
        /// </summary>
        public override CqActionType ActionType => CqActionType.GetGroupList;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupListActionParamsModel();
        }
    }
}
