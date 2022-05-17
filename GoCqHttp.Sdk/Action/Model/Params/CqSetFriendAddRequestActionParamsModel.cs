namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetFriendAddRequestActionParamsModel : CqActionParamsModel
    {
        public CqSetFriendAddRequestActionParamsModel(string flag, bool approve, string? remark)
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