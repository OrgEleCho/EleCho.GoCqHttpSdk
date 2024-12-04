namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetGroupMemberInformationActionParamsModel(long group_id, long user_id, bool no_cache) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public long user_id { get; } = user_id;
    public bool no_cache { get; } = no_cache;
}
