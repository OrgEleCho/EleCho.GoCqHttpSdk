#pragma warning disable IDE1006 // Naming Styles

using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

[method: JsonConstructor]
internal class CqCreateGroupFolderActionParamsModel(long group_id, string name, string parent_id) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public string name { get; } = name;
    public string parent_id { get; } = parent_id;
}