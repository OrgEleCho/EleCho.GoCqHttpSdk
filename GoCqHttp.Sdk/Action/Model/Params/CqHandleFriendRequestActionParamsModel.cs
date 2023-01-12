namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqHandleFriendRequestActionParamsModel : CqActionParamsModel
    {
        public CqHandleFriendRequestActionParamsModel(string flag, bool approve, string? remark)
        {
            this.flag = flag;
            this.approve = approve;
            this.remark = remark;
        }

        public string flag { get; set; }
        public bool approve { get; set; }
        public string? remark { get; set; }
    }
}