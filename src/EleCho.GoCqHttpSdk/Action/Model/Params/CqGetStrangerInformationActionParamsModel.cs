#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetStrangerInformationActionParamsModel(long user_id, bool no_cache) : CqActionParamsModel
{
    public long user_id { get; } = user_id;
    public bool no_cache { get; } = no_cache;
}