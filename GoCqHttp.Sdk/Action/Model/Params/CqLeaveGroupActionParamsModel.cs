#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqLeaveGroupActionParamsModel : CqActionParamsModel
    {
        public CqLeaveGroupActionParamsModel(long group_id, bool is_dismiss)
        {
            this.group_id = group_id;
            this.is_dismiss = is_dismiss;
        }

        public long group_id { get; set; }
        public bool is_dismiss { get; set; }
    }
}
