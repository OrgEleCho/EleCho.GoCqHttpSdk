using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetUnidirectionalFriendListAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetUnidirectionalFriendList;

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetUnidirectionalFriendListActionParamsModel();
        }
    }
}
