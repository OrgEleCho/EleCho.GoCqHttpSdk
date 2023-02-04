using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupListAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.GetGroupList;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupListActionParamsModel();
        }
    }
}
