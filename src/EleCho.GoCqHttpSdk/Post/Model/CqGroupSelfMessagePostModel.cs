#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqGroupSelfMessagePostModel : CqSelfMessagePostModel
    {
        public override string message_type => "group";

        public long group_id { get; set; }
        public CqAnonymousInformationModel? anonymous { get; set; }
        public CqGroupMessageSenderModel sender { get; set; }
    }
}