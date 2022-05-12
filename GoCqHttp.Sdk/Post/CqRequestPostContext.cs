using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post
{
    public abstract class CqRequestPostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.Request;
        public abstract CqRequestType RequestType { get; }
    }
}
