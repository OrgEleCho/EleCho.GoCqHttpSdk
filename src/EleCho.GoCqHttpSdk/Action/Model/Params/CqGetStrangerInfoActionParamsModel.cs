#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetStrangerInformationActionParamsModel : CqActionParamsModel
    {
        public CqGetStrangerInformationActionParamsModel(long user_id, bool no_cache)
        {
            this.user_id = user_id;
            this.no_cache = no_cache;
        }

        public long user_id { get; }
        public bool no_cache { get; }
    }
}