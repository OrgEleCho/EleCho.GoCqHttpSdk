#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqRequestGroupPostModel : CqRequestPostModel
{
    public override string request_type => "group";

    /// <summary>
    /// <see cref="CqGroupRequestType"/>
    /// </summary>
    public string sub_type { get; set; }

    public long group_id { get; set; }
    public long user_id { get; set; }
    public string comment { get; set; }
    public string flag { get; set; }
}