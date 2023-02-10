using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 处理群请求操作 (加群 / 邀请加群)
    /// </summary>
    public class CqHandleGroupRequestAction : CqAction
    {
        /// <summary>
        /// 操作类型: 处理群请求
        /// </summary>
        public override CqActionType ActionType => CqActionType.HandleGroupRequest;

        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="flag">请求标志 (从群请求上报中获取)</param>
        /// <param name="requestType">请求类型</param>
        /// <param name="approve">同意</param>
        /// <param name="reason">原因 (仅当拒绝时可用)</param>
        public CqHandleGroupRequestAction(string flag, CqGroupRequestType requestType, bool approve, string? reason)
        {
            Flag = flag;
            RequestType = requestType;
            Approve = approve;
            Reason = reason;
        }

        /// <summary>
        /// 请求标志 (从群请求上报中获取)
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 群请求类型
        /// </summary>
        public CqGroupRequestType RequestType { get; set; }

        /// <summary>
        /// 同意
        /// </summary>
        public bool Approve { get; set; }

        /// <summary>
        /// 原因 (拒绝原因, 仅在拒绝时可用)
        /// </summary>
        public string? Reason { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqHandleGroupRequestActionParamsModel(Flag, CqEnum.GetString(RequestType) ?? "", Approve, Reason);
        }
    }
}