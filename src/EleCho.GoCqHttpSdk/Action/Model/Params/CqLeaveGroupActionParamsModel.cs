#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqLeaveGroupActionParamsModel(long group_id, bool is_dismiss) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public bool is_dismiss { get; } = is_dismiss;
}
