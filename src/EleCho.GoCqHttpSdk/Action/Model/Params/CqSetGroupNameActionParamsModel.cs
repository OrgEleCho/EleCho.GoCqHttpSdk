#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetGroupNameActionParamsModel(long group_id, string group_name) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string group_name { get; } = group_name;
}
