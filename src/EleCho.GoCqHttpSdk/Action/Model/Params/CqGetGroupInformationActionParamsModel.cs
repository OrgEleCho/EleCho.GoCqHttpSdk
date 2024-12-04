namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetGroupInformationActionParamsModel(long group_id, bool no_cache) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public bool no_cache { get; } = no_cache;
}
