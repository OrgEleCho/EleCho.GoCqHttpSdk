namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupAddRequestActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupAddRequestActionParamsModel(string flag, string type, bool approve, string? reason)
        {
            this.flag = flag;
            this.type = type;
            this.approve = approve;
            this.reason = reason;
        }

        public string flag { get; set; }
        public string type { get; set; }
        public bool approve { get; set; }
        public string? reason { get; set; }
    }
}