using EleCho.GoCqHttpSdk.DataStructure.Model;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqBanGroupAnonymousMemberActionParamsModel(long group_id, CqAnonymousInformationModel? anonymous, string? anonymous_flag, long duration) : CqActionParamsModel
{
    public long group_id { get; } = group_id;
    public CqAnonymousInformationModel? anonymous { get; } = anonymous;
    public string? anonymous_flag { get; } = anonymous_flag;
    public long duration { get; } = duration;
}
