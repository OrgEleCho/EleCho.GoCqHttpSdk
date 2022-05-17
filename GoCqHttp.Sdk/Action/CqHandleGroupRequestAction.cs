using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqHandleGroupRequestAction : CqAction
    {
        public override CqActionType Type => CqActionType.HandleGroupRequest;

        public CqHandleGroupRequestAction(string flag, CqGroupRequestType requestType, bool approve, string? reason)
        {
            Flag = flag;
            RequestType = requestType;
            Approve = approve;
            Reason = reason;
        }

        public string Flag { get; set; }
        public CqGroupRequestType RequestType { get; set; }
        public bool Approve { get; set; }
        public string? Reason { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupAddRequestActionParamsModel(Flag, CqEnum.GetString(RequestType) ?? "", Approve, Reason);
        }
    }
}