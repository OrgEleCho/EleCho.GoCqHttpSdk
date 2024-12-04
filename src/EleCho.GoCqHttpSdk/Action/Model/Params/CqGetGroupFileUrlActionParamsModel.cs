#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqGetGroupFileUrlActionParamsModel(long group_id, string file_id, int busid) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string file_id { get; } = file_id;
    public int busid { get; } = busid;
}