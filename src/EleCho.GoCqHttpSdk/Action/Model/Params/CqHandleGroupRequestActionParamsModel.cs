#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqHandleGroupRequestActionParamsModel(string flag, string type, bool approve, string? reason) : CqActionParamsModel
{
    public string flag { get; } = flag;
    public string type { get; } = type;
    public bool approve { get; } = approve;
    public string? reason { get; } = reason;
}