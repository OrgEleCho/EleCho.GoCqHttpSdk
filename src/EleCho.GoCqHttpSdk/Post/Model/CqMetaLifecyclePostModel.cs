#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqMetaLifecyclePostModel : CqMetaPostModel
{
    public override string meta_event_type => "lifecycle";
    public string sub_type { get; set; }
}