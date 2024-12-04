#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqUploadGroupFileActionParamsModel(long group_id, string file, string name, string? folder) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string file { get; } = file;
    public string name { get; } = name;
    public string? folder { get; } = folder;
}