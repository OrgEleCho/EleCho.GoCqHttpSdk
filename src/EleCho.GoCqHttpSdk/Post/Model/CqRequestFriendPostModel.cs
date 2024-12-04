#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Post.Model.Base;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqRequestFriendPostModel : CqRequestPostModel
{
    public override string request_type => "friend";

    public long user_id { get; set; }
    public string comment { get; set; }
    public string flag { get; set; }
}