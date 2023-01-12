namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqKickGroupMemberActionParamsModel : CqActionParamsModel
    {
        public CqKickGroupMemberActionParamsModel(long group_id, long user_id, bool reject_add_request)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.reject_add_request = reject_add_request;
        }

        public long group_id { get; set; }
        public long user_id { get; set; }
        public bool reject_add_request { get; set; }
    }
}