namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqBanGroupMemberActionParamsModel : CqActionParamsModel
    {
        public CqBanGroupMemberActionParamsModel(long group_id, long user_id, long duration)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.duration = duration;
        }

        public long group_id { get; set; }
        public long user_id { get; set; }
        public long duration { get; set; }
    }
}