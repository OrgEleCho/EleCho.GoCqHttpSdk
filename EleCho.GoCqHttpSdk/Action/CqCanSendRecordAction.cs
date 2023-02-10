using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 检查是否能够发送语音的操作
    /// </summary>
    public class CqCanSendRecordAction : CqAction
    {
        /// <summary>
        /// 操作类型: 能发送语音
        /// </summary>
        public override CqActionType ActionType => CqActionType.CanSendRecord;

        internal override CqActionParamsModel GetParamsModel() => new CqCanSendRecordActionParamsModel();
    }
}
