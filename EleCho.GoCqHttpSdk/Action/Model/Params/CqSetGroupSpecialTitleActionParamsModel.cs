#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupSpecialTitleActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupSpecialTitleActionParamsModel(long group_id, long user_id, string special_title, long duration)
        {
            this.group_id = group_id;
            this.user_id = user_id;
            this.special_title = special_title;
            this.duration = duration;
        }

        public long group_id { get; }
        public long user_id { get; }
        public string special_title { get; }
        public long duration { get; }
    }
}
