namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetGroupListActionParamsModel : CqActionParamsModel
    {
        public CqGetGroupListActionParamsModel(bool no_cache)
        {
            this.no_cache = no_cache;
        }

        public bool no_cache { get; set; }
    }
}