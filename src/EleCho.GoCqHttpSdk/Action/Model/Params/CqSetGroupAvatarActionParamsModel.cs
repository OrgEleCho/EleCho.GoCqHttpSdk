namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetGroupAvatarActionParamsModel(long group_id, string file, int cache) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string file { get; } = file;

    /// <summary>
    /// boolean to integer
    /// </summary>
    public int cache { get; } = cache;
}
