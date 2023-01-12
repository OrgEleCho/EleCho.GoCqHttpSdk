using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqHandleFriendRequestAction : CqAction
    {
        public override CqActionType Type => CqActionType.HandleFriendRequest;

        public CqHandleFriendRequestAction(string flag, bool approve, string? remark)
        {
            Flag = flag;
            Approve = approve;
            Remark = remark;
        }


        public string Flag { get; set; }
        public bool Approve { get; set; }
        public string? Remark { get; set; }
        

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqHandleFriendRequestActionParamsModel(Flag, Approve, Remark);
        }
    }
}