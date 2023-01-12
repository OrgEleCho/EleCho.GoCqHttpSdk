namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqBanGroupAllMembersActionParamsModel : CqActionParamsModel
    {
        public CqBanGroupAllMembersActionParamsModel(long group_id, bool enable)
        {
            this.group_id = group_id;
            this.enable = enable;
        }

        public long group_id { get; set; }
        public bool enable { get; set; }
    }
}