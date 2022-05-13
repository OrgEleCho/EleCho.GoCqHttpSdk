namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqGroupMessagePostModel : CqMessagePostModel
    {
        public override string message_type => "group";

        public long group_id { get; set; }
        public CqMessageAnonymousModel? anonymous { get; set; }
    }
}