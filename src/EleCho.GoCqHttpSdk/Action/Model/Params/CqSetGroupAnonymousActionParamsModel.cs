#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetGroupAnonymousActionParamsModel(long group_id, bool enable) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public bool enable { get; } = enable;
}
