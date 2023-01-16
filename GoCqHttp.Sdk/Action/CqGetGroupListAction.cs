using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupListAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetGroupList;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupListActionParamsModel();
        }
    }
}
