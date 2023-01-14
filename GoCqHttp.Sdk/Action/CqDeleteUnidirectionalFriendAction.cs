using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDeleteUnidirectionalFriendAction : CqAction
    {
        public CqDeleteUnidirectionalFriendAction(long userId)
        {
            UserId = userId;
        }

        public override CqActionType Type => CqActionType.DeleteUnidirectionalFriend;

        public long UserId { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqDeleteUnidirectionalFriendActionParamsModel(UserId);
        }
    }
}
