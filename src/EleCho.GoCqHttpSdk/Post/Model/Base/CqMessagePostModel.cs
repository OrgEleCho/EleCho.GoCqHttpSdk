#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.Message.DataModel;

namespace EleCho.GoCqHttpSdk.Post.Model.Base;

internal abstract class CqMessagePostModel : CqPostModel
{
    public override string post_type => "message";
    public abstract string message_type { get; }

    public string sub_type { get; set; }
    public long message_id { get; set; }
    public long user_id { get; set; }
    public CqMsgModel[] message { get; set; }
    public string raw_message { get; set; }
    public int font { get; set; }
}