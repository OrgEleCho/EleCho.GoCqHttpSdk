namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqGroupMessagePostModel : CqMessagePostModel
    {
        public override string message_type => "group";

        public long group_id { get; set; }
        public CqAnonymousInformationModel? anonymous { get; set; }
        public CqGroupMsgSenderModel sender { get; set; }
    }
}