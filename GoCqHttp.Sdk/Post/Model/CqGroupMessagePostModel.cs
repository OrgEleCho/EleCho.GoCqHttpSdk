#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqGroupMessagePostModel : CqMessagePostModel
    {
        public override string message_type => "group";

        public long group_id { get; set; }
        public CqAnonymousInformationModel? anonymous { get; set; }
        public CqGroupMessageSenderModel sender { get; set; }
    }
}