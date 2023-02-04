using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqCanSendRecordAction : CqAction
    {
        public override CqActionType ActionType => CqActionType.CanSendRecord;

        internal override CqActionParamsModel GetParamsModel() => new CqCanSendRecordActionParamsModel();
    }
}
