#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqKickGroupMemberActionParamsModel(long group_id, long user_id, bool reject_add_request) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public long user_id { get; } = user_id;
    public bool reject_add_request { get; } = reject_add_request;
}