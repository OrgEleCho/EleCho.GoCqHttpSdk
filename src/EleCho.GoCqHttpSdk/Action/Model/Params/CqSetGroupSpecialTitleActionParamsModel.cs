#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetGroupSpecialTitleActionParamsModel(long group_id, long user_id, string special_title, long duration) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public long user_id { get; } = user_id;
    public string special_title { get; } = special_title;
    public long duration { get; } = duration;
}
