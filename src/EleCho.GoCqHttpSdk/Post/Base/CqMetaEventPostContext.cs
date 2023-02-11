

namespace EleCho.GoCqHttpSdk.Post
{
    public abstract class CqMetaEventPostContext : CqPostContext
    {
        public override CqPostType PostType => CqPostType.MetaEvent;
        public abstract CqMetaEventType MetaEventType { get; }
    }
}