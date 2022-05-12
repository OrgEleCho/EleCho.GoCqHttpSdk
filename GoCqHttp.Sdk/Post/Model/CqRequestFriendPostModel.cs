namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqRequestFriendPostModel : CqRequestPostModel
    {
        public override string request_type => "friend";

        public long user_id { get; set; }
        public string comment { get; set; }
        public string flag { get; set; }
    }
}
