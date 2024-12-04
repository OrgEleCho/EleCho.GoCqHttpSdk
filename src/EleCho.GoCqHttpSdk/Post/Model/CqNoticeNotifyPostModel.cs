#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal abstract class CqNoticeNotifyPostModel : CqNoticePostModel
{
    public override string notice_type => "notify";
    public abstract string sub_type { get; }
}