#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqPrivateMessagePostModel : CqMessagePostModel
{
    public override string message_type => "private";

    /// <summary>
    /// <see cref="CqTempSource"/>
    /// </summary>
    public int temp_source { get; set; }
    public CqMessageSenderModel sender { get; set; }
}