namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 加群请求快速操作
    /// </summary>
    public class CqGroupRequestPostQuickOperation : CqPostQuickOperation
    {
        /// <summary>
        /// 同意
        /// </summary>
        public bool? Approve { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        internal override object? GetModel()
        {
            return new
            {
                approve = Approve,
                remark = Remark
            };
        }
    }
}