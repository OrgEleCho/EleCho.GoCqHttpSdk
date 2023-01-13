#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqHandleGroupRequestActionParamsModel : CqActionParamsModel
    {
        public CqHandleGroupRequestActionParamsModel(string flag, string type, bool approve, string? reason)
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