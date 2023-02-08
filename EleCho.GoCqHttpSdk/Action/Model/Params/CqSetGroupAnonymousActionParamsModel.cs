#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupAnonymousActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupAnonymousActionParamsModel(long group_id, bool enable)
        {
            this.group_id = group_id;
            this.enable = enable;
        }

        public long group_id { get; }
        public bool enable { get; }
    }
}
