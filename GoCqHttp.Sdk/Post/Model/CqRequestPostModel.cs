namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal abstract class CqRequestPostModel : CqPostModel
    {
        public override string post_type => "request";
        public abstract string request_type { get; }
    }
}