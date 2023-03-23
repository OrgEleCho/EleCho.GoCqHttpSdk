namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetGroupMemberListActionParamsModel : CqActionParamsModel
    {
        public CqGetGroupMemberListActionParamsModel(long group_id, bool no_cache)
        {
            this.group_id = group_id;
            this.no_cache = no_cache;
        }

        public long group_id { get; }
        public bool no_cache { get; }
    }
}
