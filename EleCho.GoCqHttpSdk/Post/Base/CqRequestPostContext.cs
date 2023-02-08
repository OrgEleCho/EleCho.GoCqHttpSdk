

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqRequestPostContext : CqPostContext
    {
        public override CqPostType PostType => CqPostType.Request;
        public abstract CqRequestType RequestType { get; }
    }
}