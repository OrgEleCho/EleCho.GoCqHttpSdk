using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post
{
    public abstract class CqMetaEventPostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.MetaEvent;
        public abstract CqMetaType MetaEventType { get; }
    }
}