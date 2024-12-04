#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqHandleFriendRequestActionParamsModel(string flag, bool approve, string? remark) : CqActionParamsModel
{
    public string flag { get; } = flag;
    public bool approve { get; } = approve;
    public string? remark { get; } = remark;
}