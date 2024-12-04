#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqBanGroupMemberActionParamsModel(long group_id, long user_id, long duration) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public long user_id { get; } = user_id;
    public long duration { get; } = duration;
}