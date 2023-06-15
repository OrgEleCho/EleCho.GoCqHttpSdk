#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqPrivateMessageSentPostModel : CqPrivateMessagePostModel
    {
        public override string post_type => "message_sent";
    }
}