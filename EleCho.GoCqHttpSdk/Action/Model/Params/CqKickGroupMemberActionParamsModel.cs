#pragma warning disable IDE1006 // Naming Styles

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

        public long group_id { get; }
        public long user_id { get; }
        public bool reject_add_request { get; }
    }
}