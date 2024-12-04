#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqDeleteGroupFolderActionParamsModel(long group_id, string folder_id) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string folder_id { get; } = folder_id;
}