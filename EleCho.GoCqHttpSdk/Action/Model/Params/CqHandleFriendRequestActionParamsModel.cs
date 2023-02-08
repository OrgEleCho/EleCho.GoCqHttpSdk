#pragma warning disable IDE1006 // Naming Styles

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

        public string flag { get; }
        public bool approve { get; }
        public string? remark { get; }
    }
}