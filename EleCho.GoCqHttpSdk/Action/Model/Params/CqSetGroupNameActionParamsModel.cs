#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqSetGroupNameActionParamsModel : CqActionParamsModel
    {
        public CqSetGroupNameActionParamsModel(long group_id, string group_name)
        {
            this.group_id = group_id;
            this.group_name = group_name;
        }

        public long group_id { get; set; }
        public string group_name { get; set; }
    }
}
