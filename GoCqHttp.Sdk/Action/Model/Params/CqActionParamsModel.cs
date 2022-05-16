namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqActionParamsModel
    { }

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

    internal class CqGetForwardMsgActionParamsModel : CqActionParamsModel
    {
        public CqGetForwardMsgActionParamsModel(int message_id) => this.message_id = message_id;

        public int message_id { get; set; }
    }
}